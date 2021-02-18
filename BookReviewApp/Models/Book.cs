using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookReviewApp.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [Display(Name ="Tytuł:")]
        [Required]
        public string Title { get; set; }

        [Display(Name ="Opis:")]
        [Required]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Data wydania:")]
        [Required]
        public DateTime RelaseDate { get; set; }

        [Display(Name ="Liczba stron:")]
        [Required]
        public int Pages { get; set; }

        [StringLength(13)]
        [Required]
        [Display(Name ="Numer ISBN")]
        [Index(IsUnique = true)]
        public string ISBN { get; set; }

        [Display(Name ="Link do okładki:")]
        [Required]
        public string Cover { get; set; }

        [Required]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}