using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoodvaleBookReview.Models.Repositories
{
    interface ICommentRepository
    {
        IEnumerable<Comment> GetAllComments();
    }
}
