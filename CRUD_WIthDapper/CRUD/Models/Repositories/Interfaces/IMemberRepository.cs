using CRUD.Models.Repositories.Entities.Classes;

namespace CRUD.Models.Repositories.Interfaces;

public interface IMemberRepository
{
    public void Create(Member member);

    Member? Get(int id);

    List<Member> GetMembers();

    void Update(Member member);

    public void Delete(int id);
}