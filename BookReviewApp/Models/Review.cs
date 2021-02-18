using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookReviewApp.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        [Range(1,10)]
        [Required]
        [Display(Name="Ocena")]
        public int Rating { get; set; }
        [Display(Name="Opinia")]
        public string Description { get; set; }
        [Required]
        [Display(Name="Użytkownik")]
        public string Name { get; set; }
        [Required]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}