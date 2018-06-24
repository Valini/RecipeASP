using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RecipeWorld.Models;

namespace RecipeWorld.ViewModels
{
    public class RecipeFileViewModel
    {
        public RecipeFile RecipeFile { get; set; }
        public IEnumerable<Recipe> Recipes { get; set; }
       

    }
}