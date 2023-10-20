using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD_With_EntityFramework.Db.Models;

public class Member
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string Email { get; set; }
}

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.HasKey(member => member.Id);

        builder.Property(member => member.Name)
            .HasMaxLength(50);

        builder.Property(member => member.Email)
            .HasMaxLength(100)
            .IsRequired();
    }
}