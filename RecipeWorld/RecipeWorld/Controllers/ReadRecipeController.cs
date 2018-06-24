using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RecipeWorld.Models;
using RecipeWorld.ViewModels;

namespace RecipeWorld.Controllers
{
    public class ReadRecipeController : Controller
    {
        //DBContext Object
        private ApplicationDbContext _context;

        //class constructor - (shotcut for constructor=ctor)
        public ReadRecipeController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: ReadRecipe
        public ActionResult Index(int id )
        {
            // Get the specified recipe
            List<RecipeViewModel> viewModels = new List<RecipeViewModel>();

            var recipe = _context.Recipes.Where(r => r.Id == id).SingleOrDefault();


            var recipeFiles = _context.RecipeFiles.Where(rf => rf.RecipeId == recipe.Id).ToList();

            if (recipe == null || recipeFiles==null)
            {
                return HttpNotFound();
            }

            RecipeViewModel viewModel = new RecipeViewModel()
            {
                Recipe = recipe,
                RecipeFiles = recipeFiles
            };

            viewModels.Add(viewModel);

            return View(viewModel);
 
        }
    }
}