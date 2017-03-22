using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoodvaleBookReview.Models
{
    public class UserViewModel
    {
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Quote { get; set; }
        public bool Authenticated { get; set; }
    }
}
