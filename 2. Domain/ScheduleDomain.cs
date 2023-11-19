using _3._Data;
using _3._Data.Model;

namespace _2._Domain;

public class ScheduleDomain : IScheduleDomain
{
    private IScheduleData _scheduleData;

    public ScheduleDomain(IScheduleData scheduleData)
    {
        _scheduleData = scheduleData;
    }
    
    public bool Create(Schedule schedule)
    {
        var existingSchedule = _scheduleData.GetByTitle(schedule.Title);

        if (existingSchedule == null)
        {
            return _scheduleData.Create(schedule);
        }
        else
        {
            return false;
        }
    }
    
}