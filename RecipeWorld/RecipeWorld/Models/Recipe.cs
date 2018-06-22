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

        [Required]
        [MaxLength(255)]
        public String Title { get; set; }

        [Required]
        [Display(Name ="Recipe")]
        public String Contents { get; set; }

        [Required]
        public String Ingredients { get; set; }

        public User User { get; set; }
        [Required]
        public int UserId { get; set; }

        [Required]
        public int ViewCount { get; set; }
    }
}