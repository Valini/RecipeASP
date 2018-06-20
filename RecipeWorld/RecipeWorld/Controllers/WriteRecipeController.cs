using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeWorld.Controllers
{
    public class WriteRecipeController : Controller
    {
        // GET: WriteRecipe
        public ActionResult Index()
        {
            return View();
        }
    }
}