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
        throw new NotImplementedException();
    }
}