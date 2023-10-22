using AutoMapper;
using CRUD_With_EntityFramework.Db;
using CRUD_With_EntityFramework.Db.Models;
using CRUD_With_EntityFramework.Mapping.Converters;

namespace CRUD_With_EntityFramework.Mapping;

public class AppMappingProfile : Profile
{
    public AppMappingProfile(MyDbContext dbContext)
    {
        CreateMap<Member, MemberStatistic>()
            .ConvertUsing(new MemberStatisticConverter(dbContext));
    }
}