namespace CRUD.Models.Repositories.Entities.Classes;

public class Lesson
{
    public Lesson()
    {
    }

    public Lesson(string lessonName)
    {
        LessonName = lessonName;
    }

    public Lesson(string lessonName, DateTime date)
    {
        LessonName = lessonName;
        Date = date;
    }

    public int Id { get; set; }

    public string? LessonName { get; set; }

    public DateTime Date { get; set; }
}