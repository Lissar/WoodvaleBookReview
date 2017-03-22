using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoodvaleBookReview.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public User Reviewer { get; set; }
        public Book Book { get; set; }
        private List<Comment> comments = new List<Comment>();
        public List<Comment> Comments { get { return comments; } }
    }
}
