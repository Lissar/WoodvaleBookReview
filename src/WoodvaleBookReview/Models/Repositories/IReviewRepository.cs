using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoodvaleBookReview.Models.Repositories
{
    public interface IReviewRepository
    {
        IEnumerable<Review> GetAllReviews();
        Review GetReviewsByBook(int id);
        Review GetReviewsByMember(int id);
        Review GetReviewByID(int id);
        int Update(Review review);
        int Add(Review review);
    }
}
