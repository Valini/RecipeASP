using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RecipeWorld.Models
{
    public class RecipeFile
    {
        [Required]
        public int Id { get; set; }

        public Recipe Recipe { get; set; }
        [Required]
        public int RecipeId { get; set; }

        [Required]
        [MaxLength(255)]
        public String ImgFile { get; set; }
    }
}