using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RecipeWorld.Models
{
    public class Recipe
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Please enter the title of your recipe!")]
        [MaxLength(255)]
        public String Title { get; set; }

        [Required(ErrorMessage = "Explain your recipe, please!")]
        [Display(Name ="Recipe")]
        public String Contents { get; set; }

        [Required(ErrorMessage = "Please share indredients of your recipe!")]
        public String Ingredients { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public int ViewCount { get; set; }
    }
}