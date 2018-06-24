using RecipeWorld.Models;
using RecipeWorld.ViewModels;

using RecipeWorld.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace RecipeWorld.Controllers
{
    public class RecipeController : Controller
    {
        private ApplicationDbContext _context;
        public static int NumberOfRecipePerPage = 4;
        public RecipeController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Recipe
        public ActionResult Index(string SearchString, int Page=1)
        {
            List<RecipeViewModel> viewModels = new List<RecipeViewModel>();

            var recipes = _context.Recipes.ToList();

            if (!string.IsNullOrWhiteSpace(SearchString))
            {
                var tmp = recipes.AsQueryable();
                // in LINQ
                tmp = (from r in tmp where r.Title.Contains(SearchString) || r.Contents.Contains(SearchString) || r.Ingredients.Contains(SearchString) select r);

                recipes = tmp.ToList();

                ViewBag.search = SearchString;
            }

            int NumberOfRecipe = NumberOfRecipePerPage * Page;
            ViewBag.Page = Page;

            recipes = recipes.Take(NumberOfRecipe).ToList();

            foreach (var recipe in recipes)
            {
                var recipeFiles = _context.RecipeFiles.Where(rf => rf.RecipeId == recipe.Id).ToList();

                RecipeViewModel viewModel = new RecipeViewModel()
                {
                    Recipe = recipe,
                    RecipeFiles = recipeFiles
                };
                viewModels.Add(viewModel);
                
            }


            return View(viewModels);
        }

        // GET: WriteRecipe
        public ActionResult New()
        {
            var viewModel = new RecipeFormViewModel()
            {
                Recipe = new Recipe()
            };
            viewModel.Recipe.Email = "abc@recipeworld.com";
            viewModel.Recipe.CreateDate = DateTime.Today;
            viewModel.Recipe.ModifiedDate = DateTime.Today;

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Save(RecipeFormViewModel viewModel)
        {
            // 1. Save Recipe
            Recipe recipe = viewModel.Recipe;

            if (recipe.Id == 0)
            {
                _context.Recipes.Add(recipe);
            }
            recipe = _context.Recipes.Add(recipe);

            _context.SaveChanges();

            // 2. Save Recipe Files
            if(viewModel.RecipeFiles.Count > 0)
            {
                List<HttpPostedFileBase> ojbImage = viewModel.RecipeFiles;
                foreach (var file in ojbImage)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        RecipeFile recipeFile = new RecipeFile();
                        recipeFile.ImgFile = Guid.NewGuid() + Path.GetExtension(file.FileName);
                        recipeFile.RecipeId = recipe.Id;

                        file.SaveAs(Path.Combine(Server.MapPath("~/RecipeImageFiles"), recipeFile.ImgFile));

                        _context.RecipeFiles.Add(recipeFile);
                        _context.SaveChanges();
                    }
                }
            }

            return RedirectToAction("Index", "Recipe");
        }



    }
}