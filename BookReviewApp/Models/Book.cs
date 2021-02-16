using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookReviewApp.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime RelaseDate { get; set; }
        public int Pages { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}