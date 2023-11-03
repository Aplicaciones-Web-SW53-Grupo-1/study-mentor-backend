using _3._Data.Context;
using _3._Data.Model;
using Microsoft.EntityFrameworkCore;

namespace _3._Data;

public class ScoreMySqlData: IScoreData
{
    private StudyMentorDB _studyMentorDb;

    public ScoreMySqlData(StudyMentorDB studyMentorDb)
    {
        _studyMentorDb = studyMentorDb;
    }
    public Score GetById(int id)
    {
        // DB-TABLA-
        return _studyMentorDb.Scores.Where(t => t.Id == id && t.IsActive).First();
    }

    public async Task<List<Score>> GetAllAsync()
    {
        return await _studyMentorDb.Scores.Where(t=>t.IsActive).ToListAsync();
    }

    public List<Score> GetByIdStudent(int studentId)
    {
        return _studyMentorDb.Scores.Where(t => t.StudentId == studentId && t.IsActive).ToList();
    }

    public List<Score> GetByIdTutor(int tutorId)
    {
        return _studyMentorDb.Scores.Where(t => t.TutorId == tutorId && t.IsActive).ToList();
    }
    public bool Create(Score score)
    {
        try
        {
            _studyMentorDb.Scores.Add(score);
      
            _studyMentorDb.SaveChanges();
            return true;
        }
        catch (Exception error)
        {
            //log
            return false;
        }
    }
}