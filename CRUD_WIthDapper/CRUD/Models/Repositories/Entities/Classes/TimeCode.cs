using System.Data;

namespace CRUD.Models.Repositories.Entities.Classes;

public class TimeCode
{
    public TimeCode()
    {
    }

    public TimeCode(TimeSpan time, int lessonId)
    {
        Time = time;
        LessonId = lessonId;
    }

    public int Id { get; set; }

    public TimeSpan Time { get; set; }

    public int LessonId { get; set; }
}