using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD_With_EntityFramework.Db.Models;

public class TimeCode
{
    public int Id;

    public TimeOnly Time { get; set; }

    public int LessonId;

    public Lesson? Lesson;
}

public class TimeCodeConfiguration : IEntityTypeConfiguration<TimeCode>
{
    public void Configure(EntityTypeBuilder<TimeCode> builder)
    {
        builder.HasKey(timeCode => timeCode.Id);

        builder.Property(timeCode => timeCode.Time)
            .IsRequired();

        builder.Property(timeCode => timeCode.LessonId)
            .IsRequired();

        builder.HasOne(timeCode => timeCode.Lesson)
            .WithMany()
            .HasForeignKey(timeCode => timeCode.LessonId);
    }
}