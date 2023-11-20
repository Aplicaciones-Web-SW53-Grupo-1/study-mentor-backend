using _3._Data.Context;

namespace _3._Data.Model;

public class ScheduleSQLData : IScheduleData
{
    private StudyMentorDB _scheduleSqlData;

    public ScheduleSQLData(StudyMentorDB studyMentorDb)
    {
        _scheduleSqlData = studyMentorDb;
    }
    
    public string GetById(int id)
    {
        return "Schedule from SQL " + id.ToString();
    }
    
    public Schedule GetByTitle(string title)
    {
        return _scheduleSqlData.Schedules.Where(t => t.Title == title && t.IsActive).FirstOrDefault();
    }

    public bool Create(Schedule schedule)
    {
        try
        {
            _scheduleSqlData.Schedules.Add(schedule);
            _scheduleSqlData.SaveChanges();
            return true;
        }
        catch (Exception error)
        {
            //Loggear
            
            return false;
        }
    }
}