using CRUD.Models.Repositories.Entities.Classes;

namespace CRUD.Models.Repositories.Interfaces;

public interface IQuestionRepository
{
    public void Create(Question question);

    public Question? Get(int id);

    public List<Question> GetQuestions();

    public void Update(Question question);

    public void Delete(int id);
}