using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoodvaleBookReview.Models
{
    public class User : IdentityUser
    {
        public int UserID { get; set; }
        public string DisplayName { get; set; }
        public string Quote { get; set; }
    }
}
