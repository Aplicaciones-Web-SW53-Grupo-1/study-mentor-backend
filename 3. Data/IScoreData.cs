using _3._Data.Model;

namespace _3._Data;

public interface IScoreData
{ 
   
    Task<List<Score>> GetAllAsync();
    List<Score> GetByIdStudent(int studentId);
    List<Score> GetByIdTutor(int tutorId);
    bool Create(Score score);
}