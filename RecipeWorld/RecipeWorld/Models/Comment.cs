using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RecipeWorld.Models
{
    public class Comment
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int RecipeId { get; set; }

        [Required]
        public int ParentArticleId { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        public User User { get; set; }
        [Required]
        public int UserId { get; set; }

        [Required]
        public String Contents { get; set; }
    }
}