using _3._Data;
using _3._Data.Model;

namespace _2._Domain;

public class ReviewDomain: IReviewDomain
{
    private IReviewData _reviewData;

    public ReviewDomain(IReviewData reviewData)
    {
        _reviewData = reviewData;
    }
    
    public bool Create(Review review)
    {
        var rating = _reviewData.GetByRating(review.Rating);
        if (rating == null) return _reviewData.Create(review);
        return false;
    }
}