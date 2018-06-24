using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RecipeWorld.Models;
using RecipeWorld.ViewModel;

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
        public ActionResult Index(int id)
        {
            // Get the specified recipe
            var recipeInDB = _context.Recipes.SingleOrDefault(r => r.Id == id);

            if (recipeInDB == null)
            {
                return HttpNotFound();

            }

            var viewModel = new RecipeFormViewModel
            {
                Recipe = recipeInDB,
                //RecipeFiles = _context.RecipeFiles.ToList() // Get the image of recipe
            };

            return View(viewModel);
        }
    }
}