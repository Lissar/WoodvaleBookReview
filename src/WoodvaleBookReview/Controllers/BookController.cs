using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoodvaleBookReview.Models.Repositories;
using Microsoft.AspNetCore.Identity;
using WoodvaleBookReview.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WoodvaleBookReview.Controllers
{
    public class BookController : Controller
    {
        private IReviewRepository reviewRepo;
        private IBookRepository bookRepo;
        private UserManager<User> userManager;

        public BookController(UserManager<User> userMgr, IReviewRepository rRepo, IBookRepository bRepo)
        {
            reviewRepo = rRepo;
            bookRepo = bRepo;
            userManager = userMgr;
        }

        public ViewResult Reviews()
        {
            return View(reviewRepo.GetAllReviews().ToList());
        }

        public ViewResult ReviewsByBook(string title)
        {
            ViewBag.Title = title;
            return View("Reviews", reviewRepo.GetAllReviews().
                Where(r => r.Book.Title == title).ToList());
        }
    }
}
