using CRUD.Models.Repositories.Entities.Classes;
using CRUD.Models.Repositories.Interfaces;
using Dapper;
using Npgsql;

namespace CRUD.Models.Repositories.Entities.Repositories;

public class LessonRepository : ILessonRepository
{
    private readonly string _connection;

    public LessonRepository(string connection) => _connection = connection;

    public void Create(Lesson lesson)
    {
        using NpgsqlConnection db = new(_connection);
        const string sqlQuery = "INSERT INTO Lessons (LessonName, Date) VALUES (@LessonName, @Date)";
        db.Execute(sqlQuery, lesson);
    }

    public Lesson? Get(int id)
    {
        using NpgsqlConnection db = new(_connection);
        const string sqlQuery = "SELECT * FROM Lessons WHERE Id = @id";
        return db.Query<Lesson>(sqlQuery, new { id }).FirstOrDefault();
    }

    public List<Lesson> GetLessons()
    {
        using NpgsqlConnection db = new(_connection);
        const string sqlQuery = "SELECT * FROM Lessons";
        return db.Query<Lesson>(sqlQuery).ToList();
    }

    public void Update(Lesson lesson)
    {
        using NpgsqlConnection db = new(_connection);
        const string sqlQuery = "UPDATE Lessons SET LessonName = @LessonName, Date = @Date WHERE Id = @Id";
        db.Execute(sqlQuery, lesson);
    }

    public void Delete(int id)
    {
        using NpgsqlConnection db = new(_connection);
        const string sqlQuery = "DELETE FROM Lessons WHERE Id = @id";
        db.Execute(sqlQuery, new { id });
    }
}