using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoodvaleBookReview.Models.Repositories
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthorByFirstName(string firstname);
        Author GetAuthorByLastName(string lastname);
        int Update(Author author);
        int Add(Author author);
    }
}
