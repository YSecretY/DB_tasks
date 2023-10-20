using CRUD_With_EntityFramework.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_With_EntityFramework.Db;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    public DbSet<Member> Members { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<TimeCode> TimeCodes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<MemberLesson> MemberLessons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MemberConfiguration());
        modelBuilder.ApplyConfiguration(new LessonConfiguration());
        modelBuilder.ApplyConfiguration(new TimeCodeConfiguration());
        modelBuilder.ApplyConfiguration(new QuestionConfiguration());
        modelBuilder.ApplyConfiguration(new MemberLessonConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}