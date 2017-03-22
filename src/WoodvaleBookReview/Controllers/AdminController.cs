using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WoodvaleBookReview.Models;
using WoodvaleBookReview.Models.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WoodvaleBookReview.Controllers
{
    public class AdminController : Controller
    {
        private IAuthorRepository authorRepo;
        private IBookRepository bookRepo;

        public AdminController(IAuthorRepository aRepo, IBookRepository bRepo)
        {
            authorRepo = aRepo;
            bookRepo = bRepo;
        }

        [Authorize(Roles = "Admin")]
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ViewResult AddBook()
        {
            List<Author> authors = authorRepo.GetAllAuthors().ToList();
            var bookVm = new BookViewModel();

            List<SelectListItem> authorList = new List<SelectListItem>();

            foreach (Author a in authors)
            {
                authorList.Add(new SelectListItem { Text = a.FirstName + " " + a.LastName, Value = a.AuthorID.ToString() });
            }

            bookVm.AuthorList = authorList;

            return View(bookVm);
        }

        [HttpPost]
        public IActionResult AddBook(BookViewModel bookVm)
        {
            Book book = new Book();
            Author author = (from a in authorRepo.GetAllAuthors()
                         where a.AuthorID == int.Parse(bookVm.AuthorID)
                         select a).FirstOrDefault<Author>();

            if (ModelState.IsValid)
            {
                book.Authors.Add(author);
                book.Title = bookVm.Title;
                book.Genre = bookVm.Genre;
                bookRepo.Add(book);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View(bookVm);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ViewResult AddAuthor()
        {
            return View(new Author());
        }

        [HttpPost]
        public IActionResult AddAuthor(Author author)
        {
            if (ModelState.IsValid)
            {
                authorRepo.Add(author);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View(author);
            }
        }
    }
}
