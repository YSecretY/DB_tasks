namespace CRUD.Models.Repositories.Entities.Classes;

public class Member
{
    public Member()
    {
    }

    public Member(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }
}