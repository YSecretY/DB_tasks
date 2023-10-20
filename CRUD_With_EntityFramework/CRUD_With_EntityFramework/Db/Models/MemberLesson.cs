using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD_With_EntityFramework.Db.Models;

public class MemberLesson
{
    public int MemberId { get; set; }

    public Member? Member { get; set; }
    public int LessonId { get; set; }

    public Lesson? Lesson { get; set; }
}

public class MemberLessonConfiguration : IEntityTypeConfiguration<MemberLesson>
{
    public void Configure(EntityTypeBuilder<MemberLesson> builder)
    {
        builder.HasKey(memberLesson => new { memberLesson.MemberId, memberLesson.LessonId });

        builder.HasOne(memberLesson => memberLesson.Member)
            .WithMany()
            .HasForeignKey(memberLesson => memberLesson.MemberId);

        builder.HasOne(memberLesson => memberLesson.Lesson)
            .WithMany()
            .HasForeignKey(memberLesson => memberLesson.LessonId);
    }
}