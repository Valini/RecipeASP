using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RecipeWorld.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public String Email { get; set; }

        [Required]
        [MaxLength(255)]
        public String Password { get; set; }
    }
}