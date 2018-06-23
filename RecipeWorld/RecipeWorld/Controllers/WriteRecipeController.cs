using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RecipeWorld.ViewModel;
using RecipeWorld.Models;

using System.IO;

namespace RecipeWorld.Controllers
{
    public class WriteRecipeController : Controller
    {
        //DBContext Object
        private ApplicationDbContext _context;

        public WriteRecipeController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: WriteRecipe
        public ActionResult Index()
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

            if(recipe.Id == 0)
            {
                _context.Recipes.Add(recipe);
            }
            /*
            Recipe recipe = new Recipe();
            recipe.Email = "abc";
            recipe.Title = "abc";
            recipe.Ingredients = "abc";
            recipe.Contents = "abc";
            recipe.CreateDate = DateTime.Now;
            recipe.ModifiedDate = DateTime.Now;
            recipe.ViewCount = 0;
            */
            recipe = _context.Recipes.Add(recipe);

            _context.SaveChanges();

            // 2. Save Recipe Files
            if (viewModel.RecipeFiles.Count() > 0)
            {
                List<HttpPostedFileBase> ojbImage = (List <HttpPostedFileBase>)viewModel.RecipeFiles;
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