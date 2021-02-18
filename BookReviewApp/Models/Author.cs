using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookReviewApp.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Display(Name="Imię:")]
        [Required]
        public string Name { get; set; }

        [Display(Name="Nazwisko:")]
        [Required]
        public string Surname { get; set; }

        [Display(Name="Życiorys:")]
        [Required]
        public string Description { get; set; }

        [Display(Name="Link do zdjęcia")]
        [Required]
        public string Photo { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}