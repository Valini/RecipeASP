using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeWorld.Controllers
{
    public class ReadRecipeController : Controller
    {
        // GET: ReadRecipe
        public ActionResult Index()
        {
            return View();
        }
    }
}