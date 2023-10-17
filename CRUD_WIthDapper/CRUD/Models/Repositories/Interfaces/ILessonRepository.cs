using CRUD.Models.Repositories.Entities.Classes;

namespace CRUD.Models.Repositories.Interfaces;

public interface ILessonRepository
{
    public void Create(Lesson lesson);

    public Lesson? Get(int id);

    public List<Lesson> GetLessons();

    public void Update(Lesson lesson);

    public void Delete(int id);
}