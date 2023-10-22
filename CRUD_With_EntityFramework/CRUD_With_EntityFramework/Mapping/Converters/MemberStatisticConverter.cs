using AutoMapper;
using CRUD_With_EntityFramework.Db;
using CRUD_With_EntityFramework.Db.Models;

namespace CRUD_With_EntityFramework.Mapping.Converters;

public class MemberStatisticConverter : ITypeConverter<Member, MemberStatistic>
{
    private readonly MyDbContext _dbContext;

    public MemberStatisticConverter(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public MemberStatistic Convert(Member source, MemberStatistic destination, ResolutionContext context)
    {
        List<MemberLesson> memberLessons = _dbContext.MemberLessons
            .Where(memberLesson => memberLesson.MemberId == source.Id)
            .ToList();

        List<Lesson> lessons = memberLessons.SelectMany(memberLesson => _dbContext.Lessons
                .Where(lesson => lesson.Id == memberLesson.LessonId)
                .ToList())
            .ToList();

        List<Question> questions = _dbContext.Questions.Where(question => question.MemberId == source.Id).ToList();

        var result = new MemberStatistic
        {
            Id = source.Id,
            Name = source.Name,
            Email = source.Email,
            Lessons = lessons,
            Questions = questions
        };

        return result;
    }
}