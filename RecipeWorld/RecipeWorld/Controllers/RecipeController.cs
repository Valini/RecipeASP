using RecipeWorld.Models;
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

        public RecipeController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Recipe
        public ActionResult Index()
        {
            return View();
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