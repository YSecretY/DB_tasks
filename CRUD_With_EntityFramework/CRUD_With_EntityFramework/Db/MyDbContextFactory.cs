using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CRUD_With_EntityFramework.Db;

public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
{
    private const string ConnectionString = "Host=localhost;Port=5433;Database=EntityDb;Username=secret;Password=2435;";

    public MyDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<MyDbContext>();
        builder.UseNpgsql(ConnectionString);

        return new MyDbContext(builder.Options);
    }
}