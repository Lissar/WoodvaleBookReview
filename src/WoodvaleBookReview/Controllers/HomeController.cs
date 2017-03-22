using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoodvaleBookReview.Models;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WoodvaleBookReview.Controllers
{
    public class HomeController : Controller
    {

        private UserManager<User> userManager;

        public HomeController(UserManager<User> userMgr)
        {
            userManager = userMgr;
        }

        public async Task<IActionResult> Index()
        {
            var userVm = new UserViewModel { Authenticated = false };
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                string name = HttpContext.User.Identity.Name;
                User user = await userManager.FindByNameAsync(name);
                userVm.UserName = user.UserName;
                userVm.DisplayName = user.DisplayName;
                userVm.Quote = user.Quote;
                userVm.Authenticated = true;
            }
            return View(userVm);
        }
    }
}
