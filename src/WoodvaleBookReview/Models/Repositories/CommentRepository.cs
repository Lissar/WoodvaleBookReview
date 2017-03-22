using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoodvaleBookReview.Models.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private ApplicationDbContext context;

        public IEnumerable<Comment> GetAllComments()
        {
            return context.Comments;
        }
    }
}
