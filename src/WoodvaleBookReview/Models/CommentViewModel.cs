using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WoodvaleBookReview.Models
{
    public class CommentViewModel
    {
        public int ReviewID { get; set; }
        [Required]
        public string Body { get; set; }
    }
}
