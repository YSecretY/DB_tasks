using CRUD.Models.Repositories.Entities.Classes;

namespace CRUD.Models.Repositories.Interfaces;

public interface ITimeCodeRepository
{
    public void Create(TimeCode timeCode);

    public TimeCode? Get(int id);

    public List<TimeCode> GetTimeCodes();

    public void Update(TimeCode timeCode);

    public void Delete(int id);
}