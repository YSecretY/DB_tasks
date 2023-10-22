namespace CRUD_With_EntityFramework.Db.Models;

public class MemberStatistic
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string Email { get; set; }

    public ICollection<Lesson>? Lessons { get; set; }

    public ICollection<Question>? Questions { get; set; }
}