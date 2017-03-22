using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoodvaleBookReview.Models.Repositories
{
    public class BookRepository : IBookRepository
    {
        private ApplicationDbContext context;

        public BookRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return context.Books;
        }

        public Book GetBookByTitle(string title)
        {
            return context.Books.First(b => b.Title == title);
        }

        public int Update(Book book)
        {
            context.Books.Update(book);
            return context.SaveChanges();
        }

        public int Add(Book book)
        {
            context.Books.Add(book);
            return context.SaveChanges();
        }
    }
}
