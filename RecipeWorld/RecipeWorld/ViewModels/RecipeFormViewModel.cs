using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RecipeWorld.Models;

namespace RecipeWorld.ViewModel
{
    public class RecipeFormViewModel
    {
        public Recipe Recipe { get; set; }
        public List<HttpPostedFileBase> RecipeFiles { get; set; }
    }
}