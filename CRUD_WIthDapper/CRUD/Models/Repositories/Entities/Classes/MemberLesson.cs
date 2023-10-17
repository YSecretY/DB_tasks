namespace CRUD.Models.Repositories.Entities.Classes;

public class MemberLesson
{
    public MemberLesson()
    {
    }

    public MemberLesson(int memberId, int lessonId)
    {
        MemberId = memberId;
        LessonId = lessonId;
    }

    public int MemberId { get; set; }

    public int LessonId { get; set; }
}