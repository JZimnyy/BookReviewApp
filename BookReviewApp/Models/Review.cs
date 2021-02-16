using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookReviewApp.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}