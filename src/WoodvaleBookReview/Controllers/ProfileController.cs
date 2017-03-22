using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoodvaleBookReview.Models.Repositories;
using Microsoft.AspNetCore.Identity;
using WoodvaleBookReview.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WoodvaleBookReview.Controllers
{
    public class ProfileController : Controller
    {
        private IReviewRepository reviewRepo;
        private IBookRepository bookRepo;
        private UserManager<User> userManager;

        public ProfileController(UserManager<User> userMgr, IReviewRepository rRepo, IBookRepository bRepo)
        {
            reviewRepo = rRepo;
            bookRepo = bRepo;
            userManager = userMgr;
        }

        public ViewResult Profile()
        {
            return View(reviewRepo.GetAllReviews().ToList());
        }

        public ViewResult Read(int id)
        {
            return View(reviewRepo.GetReviewByID(id));
        }

        public ViewResult ReviewsByUser(string username)
        {
            ViewBag.User = username;
            return View("Profile", reviewRepo.GetAllReviews().
                Where(r => r.Reviewer.UserName == username).ToList());
        }

        [HttpGet]
        [Authorize(Roles = "Reviewer, Admin")]
        public ViewResult Comment(int id)
        {
            var commentVm = new CommentViewModel();
            commentVm.ReviewID = id;

            return View(commentVm);
        }


        [HttpPost]
        public IActionResult Comment(CommentViewModel commentVm)
        {
       
            if (ModelState.IsValid)
            {
 
                Review review = (from r in reviewRepo.GetAllReviews()
                             where r.ReviewID == commentVm.ReviewID
                             select r).FirstOrDefault<Review>();

                string name = HttpContext.User.Identity.Name;
                Comment comment = new Comment { Body = commentVm.Body, Commenter = name };
                


                review.Comments.Add(comment);
                reviewRepo.Update(review);

                return RedirectToAction("Read", "Profile", new { id = commentVm.ReviewID });
            }
            else
            {
                return View(commentVm);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Reviewer, Admin")]
        public ViewResult Write()
        {
            ReviewViewModel reviewVm = populateBookList();

            return View(reviewVm);
        }

        [HttpPost]
        public async Task<IActionResult> Write(ReviewViewModel reviewVm)
        {
            Review review = new Review();
            Book book = (from b in bookRepo.GetAllBooks()
                             where b.BookID == int.Parse(reviewVm.BookID)
                             select b).FirstOrDefault<Book>();

            if (ModelState.IsValid)
            {
                string name = HttpContext.User.Identity.Name;
                review.Reviewer = await userManager.FindByNameAsync(name);
                review.Title = reviewVm.Title;
                review.Body = reviewVm.Body;
                review.Book = book;
                reviewRepo.Add(review);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                reviewVm = populateBookList();
                return View(reviewVm);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Reviewer, Admin")]
        public ViewResult Edit()
        {
            var userVm = new UserViewModel();

            return View(userVm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel userVm)
        {

            if (ModelState.IsValid)
            {

                string name = HttpContext.User.Identity.Name;
                User user = await userManager.FindByNameAsync(name);
                if (userVm.DisplayName != null)
                {
                    user.DisplayName = userVm.DisplayName;
                }
                
                if (userVm.Quote != null)
                {
                    user.Quote = userVm.Quote;
                }
                
                await userManager.UpdateAsync(user);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(userVm);
            }
        }

        private ReviewViewModel populateBookList()
        {
            List<Book> books = bookRepo.GetAllBooks().ToList();
            var reviewVm = new ReviewViewModel();

            List<SelectListItem> bookList = new List<SelectListItem>();

            foreach (Book b in books)
            {
                bookList.Add(new SelectListItem { Text = b.Title, Value = b.BookID.ToString() });
            }

            reviewVm.BookList = bookList;

            return reviewVm;
        }
    }
}
