using CRUD.Models.Repositories.Entities.Classes;
using CRUD.Models.Repositories.Interfaces;
using Dapper;
using Npgsql;

namespace CRUD.Models.Repositories.Entities.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly string _connection;

    public QuestionRepository(string connection)
    {
        _connection = connection;
    }

    public void Create(Question question)
    {
        using NpgsqlConnection db = new(_connection);
        const string sqlQuery =
            "INSERT INTO Questions (Question, LessonId, MemberId, TimeCodeId) VALUES (@QuestionText, @LessonId, @MemberId, @TimeCodeId)";
        db.Execute(sqlQuery, question);
    }

    public Question? Get(int id)
    {
        using NpgsqlConnection db = new(_connection);
        const string sqlQuery =
            "SELECT id, Question AS QuestionText, LessonId, MemberId, TimeCodeId FROM Questions WHERE Id = @id";
        return db.Query<Question>(sqlQuery, new { id }).FirstOrDefault();
    }

    public List<Question> GetQuestions()
    {
        using NpgsqlConnection db = new(_connection);
        const string sqlQuery = "SELECT id, Question AS QuestionText, LessonId, MemberId, TimeCodeId FROM Questions";
        return db.Query<Question>(sqlQuery).ToList();
    }

    public void Update(Question question)
    {
        using NpgsqlConnection db = new(_connection);
        const string sqlQuery =
            "UPDATE Questions SET Question = @QuestionText, LessonId = @LessonId, MemberId = @MemberId, TimeCodeId = @TimeCodeId WHERE Id = @Id";
        db.Execute(sqlQuery, question);
    }

    public void Delete(int id)
    {
        using NpgsqlConnection db = new(_connection);
        const string sqlQuery = "DELETE FROM Questions WHERE Id = @id";
        db.Execute(sqlQuery, new { id });
    }
}