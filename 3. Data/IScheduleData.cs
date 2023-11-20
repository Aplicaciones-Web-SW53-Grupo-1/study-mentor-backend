using _3._Data.Model;

namespace _3._Data;

public interface IScheduleData
{
    string GetById(int id);

    Schedule GetByTitle(string title);

    bool Create(Schedule schedule);
}