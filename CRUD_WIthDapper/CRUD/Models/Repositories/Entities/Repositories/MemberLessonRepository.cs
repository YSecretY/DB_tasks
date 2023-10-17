using CRUD.Models.Repositories.Entities.Classes;
using CRUD.Models.Repositories.Interfaces;
using Dapper;
using Npgsql;

namespace CRUD.Models.Repositories.Entities.Repositories;

public class MemberLessonRepository : IMemberLessonRepository
{
    private readonly string _connection;

    public MemberLessonRepository(string connection) => _connection = connection;

    public void Create(MemberLesson memberLesson)
    {
        using NpgsqlConnection db = new(_connection);
        const string sqlQuery = "INSERT INTO MemberLessons (MemberId, LessonId) VALUES (@MemberId, @LessonId)";
        db.Execute(sqlQuery, memberLesson);
    }

    public MemberLesson? Get(MemberLesson memberLesson)
    {
        using NpgsqlConnection db = new(_connection);
        const string sqlQuery = "SELECT * FROM MemberLessons WHERE MemberId = @MemberId AND LessonId = @LessonId";
        return db.Query<MemberLesson>(sqlQuery, memberLesson).FirstOrDefault();
    }

    public List<MemberLesson> GetMemberLessons()
    {
        using NpgsqlConnection db = new(_connection);
        const string sqlQuery = "SELECT * FROM MemberLessons";
        return db.Query<MemberLesson>(sqlQuery).ToList();
    }

    public void Delete(MemberLesson memberLesson)
    {
        using NpgsqlConnection db = new(_connection);
        const string sqlQuery = "DELETE FROM MemberLessons WHERE MemberId = @MemberId AND LessonId = @LessonId";
        db.Execute(sqlQuery, memberLesson);
    }
}