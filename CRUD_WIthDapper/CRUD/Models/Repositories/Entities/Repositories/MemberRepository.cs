using System.Data;
using CRUD.Models.Repositories.Entities.Classes;
using CRUD.Models.Repositories.Interfaces;
using Dapper;
using Npgsql;

namespace CRUD.Models.Repositories.Entities.Repositories;

public class MemberRepository : IMemberRepository
{
    private readonly string _connection;

    public MemberRepository(string connection) => _connection = connection;

    public void Create(Member member)
    {
        using IDbConnection db = new NpgsqlConnection(_connection);
        const string sqlQuery = "INSERT INTO Members (Name, Email) VALUES(@Name, @Email)";
        db.Execute(sqlQuery, member);
    }

    public Member? Get(int id)
    {
        using IDbConnection db = new NpgsqlConnection(_connection);
        const string sqlQuery = "SELECT * FROM Members WHERE Id = @id";
        return db.Query<Member>(sqlQuery, new { id }).FirstOrDefault();
    }

    public List<Member> GetMembers()
    {
        using IDbConnection db = new NpgsqlConnection(_connection);
        return db.Query<Member>("SELECT * FROM Members").ToList();
    }

    public void Update(Member member)
    {
        using IDbConnection db = new NpgsqlConnection(_connection);
        const string sqlQuery = "UPDATE Members SET Name  = @Name, Email = @Email WHERE Id = @Id";
        db.Execute(sqlQuery, member);
    }

    public void Delete(int id)
    {
        using IDbConnection db = new NpgsqlConnection(_connection);
        const string sqlQuery = "DELETE FROM Members WHERE Id = @id";
        db.Execute(sqlQuery, new { id });
    }
}