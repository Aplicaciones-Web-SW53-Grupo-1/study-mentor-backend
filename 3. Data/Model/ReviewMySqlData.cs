using _3._Data.Context;
using _3._Data.Model;
using Microsoft.EntityFrameworkCore;

namespace _3._Data;

public class ReviewMySqlData: IReviewData
{
    private StudyMentorDB _studyMentorDb;

    public ReviewMySqlData(StudyMentorDB studyMentorDb)
    {
        _studyMentorDb = studyMentorDb;
    }
    
    public Review GetById(int id)
    {
        return _studyMentorDb.Reviews.Where(t => t.Id == id && t.IsActive).First();
    }
    
    public async Task<List<Review>> GetAllAsync()
    {
        return await _studyMentorDb.Reviews.Where(t=>t.IsActive).ToListAsync();
    }
    public Review GetByRating(int rating)
    {
        return _studyMentorDb.Reviews.Where(t => t.Rating==rating && t.IsActive).FirstOrDefault();
    }
    public bool Create(Review review)
    {
        try
        {
            _studyMentorDb.Reviews.Add(review);
            _studyMentorDb.SaveChanges();
            return true;
        }
        catch (Exception error)
        {
            return false;
        }
    }
}