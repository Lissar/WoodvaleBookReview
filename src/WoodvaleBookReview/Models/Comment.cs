using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoodvaleBookReview.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string Commenter { get; set; }
        public string Body { get; set; }
    }
}
