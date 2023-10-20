using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD_With_EntityFramework.Db.Models;

public class Question
{
    public int Id { get; set; }

    public string QuestionText { get; set; }

    public int LessonId { get; set; }

    public Lesson? Lesson { get; set; }

    public int MemberId { get; set; }

    public Member? Member { get; set; }

    public int TimeCodeId { get; set; }

    public TimeCode? TimeCode { get; set; }
}

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasKey(question => question.Id);

        builder.Property(question => question.LessonId)
            .IsRequired();

        builder.Property(question => question.MemberId)
            .IsRequired();

        builder.Property(question => question.TimeCodeId)
            .IsRequired();

        builder.Property(question => question.QuestionText)
            .HasColumnName("Question")
            .IsRequired();

        builder.HasOne(question => question.Lesson)
            .WithMany()
            .HasForeignKey(question => question.LessonId);

        builder.HasOne(question => question.Member)
            .WithMany()
            .HasForeignKey(question => question.MemberId);

        builder.HasOne(question => question.TimeCode)
            .WithMany()
            .HasForeignKey(question => question.TimeCodeId);
    }
}