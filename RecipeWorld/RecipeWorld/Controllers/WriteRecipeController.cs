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
            /*
            Recipe recipe = viewModel.Recipe;

            if(recipe.Id == 0)
            {
                _context.Recipes.Add(recipe);
            }
            */
            Recipe recipe = new Recipe();
            recipe.Email = "abc";
            recipe.Title = "abc";
            recipe.Ingredients = "abc";
            recipe.Contents = "abc";
            recipe.CreateDate = DateTime.Now;
            recipe.ModifiedDate = DateTime.Now;
            recipe.ViewCount = 0;
            _context.Recipes.Add(recipe);


            // 2. Save Recipe Files
            List<HttpPostedFileBase> ojbImage = viewModel.RecipeFiles;
            foreach (var file in ojbImage)
            {
                if (file != null && file.ContentLength > 0)
                {
                    file.SaveAs(Path.Combine(Server.MapPath("~/Images"), Guid.NewGuid() + Path.GetExtension(file.FileName)));
                }
            }
            return RedirectToAction("Index", "Recipe");
        }
    }
}