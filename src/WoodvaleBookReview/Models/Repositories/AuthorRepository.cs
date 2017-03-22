using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoodvaleBookReview.Models.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private ApplicationDbContext context;

        public AuthorRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return context.Authors;
        }

        public Author GetAuthorByFirstName(string firstname)
        {
            return context.Authors.First(a => a.FirstName == firstname);
        }

        public Author GetAuthorByLastName(string lastname)
        {
            return context.Authors.First(a => a.LastName == lastname);
        }

        public int Update(Author author)
        {
            context.Authors.Update(author);
            return context.SaveChanges();
        }

        public int Add(Author author)
        {
            context.Authors.Add(author);
            return context.SaveChanges();
        }
    }
}
