using _3._Data.Context;

namespace _3._Data.Model;

public class ReviewMySqlData: IReviewData
{
    private StudyMentorDB _studyMentorDb;

    public ReviewMySqlData(StudyMentorDB studyMentorDb)
    {
        _studyMentorDb = studyMentorDb;
    }
    
    public Review GetById(int id)
    {
        throw new NotImplementedException();
    }

    public bool Create(Review review)
    {
        throw new NotImplementedException();
    }
}