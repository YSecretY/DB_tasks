using System.Linq.Expressions;
using System.Xml;
using CRUD_With_EntityFramework.Db;
using CRUD_With_EntityFramework.Db.Models;

namespace CRUD_With_EntityFramework;

internal abstract class Program
{
    private static readonly MyDbContextFactory ContextFactory = new();
    private static readonly MyDbContext DbContext = ContextFactory.CreateDbContext(Array.Empty<string>());

    public static void Main(string[] args)
    {
        List<Member> members = DbContext.Members.ToList();
        foreach (Member member in members)
        {
            Console.WriteLine(member.Name);
        }

        Member? member10 = DbContext.Members.FirstOrDefault(member => member.Name == "member_10");
        if (member10 != null) member10.Name = "Bogdan";

        MemberLesson? memberLesson =
            DbContext.MemberLessons.FirstOrDefault(memberLesson => memberLesson.MemberId == 10);
        if (memberLesson != null) DbContext.MemberLessons.Remove(memberLesson);

        DbContext.SaveChanges();
    }

    private static void Add100Members()
    {
        for (int i = 0; i < 100; ++i)
        {
            Member member = new();
            member.Name = $"member_{i}";
            member.Email = $"member_{i}@email.com";

            DbContext.Members.Add(member);
        }

        DbContext.SaveChanges();
    }

    private static void Add100Lessons()
    {
        for (int i = 0; i < 100; ++i)
        {
            Lesson lesson = new();
            lesson.LessonName = $"lessonName_{i}";
            lesson.Date = DateTime.UtcNow.AddDays(i);

            DbContext.Lessons.Add(lesson);
        }

        DbContext.SaveChanges();
    }

    private static void Add100MemberLessons()
    {
        for (int i = 1; i < 101; ++i)
        {
            var memberLesson = new MemberLesson
            {
                MemberId = i,
                LessonId = i
            };

            DbContext.MemberLessons.Add(memberLesson);
        }

        DbContext.SaveChanges();
    }

    private static void Add100TimeCodes()
    {
        for (int i = 1; i < 101; ++i)
        {
            var timeCode = new TimeCode
            {
                Time = TimeOnly.FromDateTime(DateTime.UtcNow),
                LessonId = i
            };

            DbContext.TimeCodes.Add(timeCode);
        }

        DbContext.SaveChanges();
    }

    private static void Add100Questions()
    {
        for (int i = 1; i < 101; ++i)
        {
            var question = new Question
            {
                LessonId = i,
                MemberId = i,
                TimeCodeId = i,
                QuestionText = $"question text {i}"
            };

            DbContext.Questions.Add(question);
        }

        DbContext.SaveChanges();
    }
}