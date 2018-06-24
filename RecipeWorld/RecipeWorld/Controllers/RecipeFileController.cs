using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecipeWorld.ViewModels;
using RecipeWorld.Models;
using RecipeWorld.ViewModel;


namespace RecipeWorld.Controllers
{
    public class RecipeFileController : Controller
    {
        //DBContext Object
        private ApplicationDbContext _context;

        //class constructor - (shotcut for constructor=ctor)
        public RecipeFileController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: RecipeFile
        public ActionResult Index()
        {
            //var recipeFiles = _context.RecipeFiles.ToList();
            // return View(recipeFiles);

            var viewModel = new RecipeFileViewModel()
            {
                RecipeFile = new RecipeFile(),
                Recipes = _context.Recipes.ToList(),

            };

            /*var viewModel = new RecipeFormViewModel()
            {
                Recipe = new Recipe(),
                RecipeFiles=_context.RecipeFiles.ToList()

            };*/

            return View("Index", viewModel);

        }

        //GET: Recipe/Details
        public ActionResult Read(int id)
        {
            //var customer = GetCustomers().SingleOrDefault(c => c.ID == id);
            var recipe = _context.Recipes.SingleOrDefault(r => r.Id == id);
            var image = _context.RecipeFiles.Where(r => r.RecipeId == id).SingleOrDefault();
            if (recipe == null)
            {
                return HttpNotFound();
            }


            {
                return View(recipe);

            }



        }
        //get image
        public ActionResult GetImage(int id)
        {

            var image = _context.RecipeFiles.Where(r => r.RecipeId == id).SingleOrDefault();
            if (image == null)
            {
                return HttpNotFound();
            }


            {
                return View(image);
            }

        }

        //GET: Recipe/Details
        public ActionResult Read(RecipeFileViewModel viewModel)
        {
            
            var recipe = _context.Recipes.SingleOrDefault(r => r.Id == viewModel.RecipeFile.RecipeId);
            var image = _context.RecipeFiles.Where(r => r.Id == viewModel.RecipeFile.Id).SingleOrDefault();
            if (recipe == null || image == null)
            {
                return HttpNotFound();
            }


            {
                return View(recipe);

            }



        }
    }
}