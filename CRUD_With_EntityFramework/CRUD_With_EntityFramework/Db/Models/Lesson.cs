using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD_With_EntityFramework.Db.Models;

public class Lesson
{
    public int Id { get; set; }

    public string? LessonName { get; set; }

    public DateTime Date { get; set; }
}

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.HasKey(lesson => lesson.Id);

        builder.Property(lesson => lesson.LessonName)
            .HasMaxLength(50);
    }
}