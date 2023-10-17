using CRUD.Models.Repositories.Entities.Classes;

namespace CRUD.Models.Repositories.Interfaces;

public interface IMemberLessonRepository
{
    public void Create(MemberLesson memberLesson);

    public MemberLesson? Get(MemberLesson memberLesson);

    public List<MemberLesson> GetMemberLessons();

    public void Delete(MemberLesson memberLesson);
}