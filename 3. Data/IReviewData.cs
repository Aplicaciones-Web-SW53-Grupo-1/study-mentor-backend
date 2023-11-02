using _3._Data.Model;

namespace _3._Data;

public interface IReviewData
{
    Review GetById(int id);
    Task<List<Review>> GetAllAsync();
    Review GetByRating(int rating);
    bool Create(Review review);
}

