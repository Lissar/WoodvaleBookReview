using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoodvaleBookReview.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        private List<Author> authors = new List<Author>();
        public List<Author> Authors { get { return authors; } }
    }
}
