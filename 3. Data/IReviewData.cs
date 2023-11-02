namespace _3._Data.Model;

public interface IReviewData
{
    Review GetById(int id);

    bool Create(Review review);
}