using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WoodvaleBookReview.Models
{
    public class ReviewViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        public string BookID { get; set; }
        public IEnumerable<SelectListItem> BookList { get; set; }
    }
}
