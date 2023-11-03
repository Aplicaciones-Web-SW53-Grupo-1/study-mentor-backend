namespace _3._Data.Model;

public class ScheduleSQLData : IScheduleData
{
    public string GetById(int id)
    {
        return "Schedule from SQL " + id.ToString();
    }
}