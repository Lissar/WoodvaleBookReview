using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoodvaleBookReview.Models.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private ApplicationDbContext context;

        public ReviewRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Review> GetAllReviews()
        {
            return context.Reviews.Include(r => r.Reviewer).Include(r => r.Book);
        }

        public Review GetReviewsByBook(int id)
        {
            return context.Reviews.First(r => r.Book.BookID == id);
        }

        public Review GetReviewsByMember(int id)
        {
            return context.Reviews.First(r => r.Reviewer.UserID == id);
        }

        public Review GetReviewByID(int id)
        {
            return context.Reviews.Include(r => r.Reviewer).Include(r => r.Book).Include(r => r.Comments).First(r => r.ReviewID == id);
        }

        public List<Comment> GetCommentsByReview(Review review)
        {
            return review.Comments;
        }

        public int Update(Review review)
        {
            context.Reviews.Update(review);
            return context.SaveChanges();
        }

        public int Add(Review review)
        {
            context.Reviews.Add(review);
            return context.SaveChanges();
        }
    }
}
