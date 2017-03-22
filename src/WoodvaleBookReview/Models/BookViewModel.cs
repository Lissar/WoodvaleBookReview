using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WoodvaleBookReview.Models
{
    public class BookViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Genre { get; set; }
        public string AuthorID { get; set; }
        public IEnumerable<SelectListItem> AuthorList { get; set; }
    }
}
