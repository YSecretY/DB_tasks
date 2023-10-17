using CRUD.Models.Repositories.Entities.Classes;
using CRUD.Models.Repositories.Interfaces;
using Dapper;
using Npgsql;

namespace CRUD.Models.Repositories.Entities.Repositories;

public class TimeCodeRepository : ITimeCodeRepository
{
    private readonly string _connection;

    public TimeCodeRepository(string connection) => _connection = connection;

    public void Create(TimeCode timeCode)
    {
        using NpgsqlConnection db = new(_connection);
        const string sqlQuery = "INSERT INTO TimeCodes (Time, LessonId) VALUES (@Time, @LessonId)";
        db.Execute(sqlQuery, timeCode);
    }

    public TimeCode? Get(int id)
    {
        using NpgsqlConnection db = new(_connection);
        const string sqlQuery = "SELECT * FROM TimeCodes WHERE Id = @id";
        return db.Query<TimeCode>(sqlQuery, new { id }).FirstOrDefault();
    }

    public List<TimeCode> GetTimeCodes()
    {
        using NpgsqlConnection db = new(_connection);
        const string sqlQuery = "SELECT * FROM TimeCodes";
        return db.Query<TimeCode>(sqlQuery).ToList();
    }

    public void Update(TimeCode timeCode)
    {
        using NpgsqlConnection db = new(_connection);
        const string sqlQuery = "UPDATE TimeCodes SET Time = @Time, LessonId = @LessonId WHERE Id = @Id";
        db.Execute(sqlQuery, timeCode);
    }

    public void Delete(int id)
    {
        using NpgsqlConnection db = new(_connection);
        const string sqlQuery = "DELETE FROM TimeCodes WHERE Id = @id";
        db.Execute(sqlQuery, new { id });
    }
}