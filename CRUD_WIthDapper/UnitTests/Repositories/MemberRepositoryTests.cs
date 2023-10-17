using CRUD.Models.Repositories.Entities.Classes;
using CRUD.Models.Repositories.Entities.Repositories;
using CRUD.Models.Repositories.Interfaces;
using Moq;

namespace UnitTests.Repositories;

public class MemberRepositoryTests
{
    [Fact]
    public void GetMemberById_ShouldReturnMember_WhenMemberExists()
    {
        // Arrange
        const int memberId = 1;
        Member expectedMember = new Member { Id = memberId, Name = "John Doe", Email = "john@example.com" };

        Mock<IMemberRepository> memberRepositoryMock = new();
        memberRepositoryMock.Setup(repo => repo.Get(memberId)).Returns(expectedMember);

        var repository = memberRepositoryMock.Object;

        // Act
        Member? actualMember = repository.Get(memberId);

        // Assert
        Assert.NotNull(actualMember);
        Assert.Equal(expectedMember, actualMember);
    }

    [Fact]
    public void GetAllMembers_ShouldReturn_ListOfMembers()
    {
        // Arrange
        List<Member> expectedMembers = new()
        {
            new Member { Id = 1, Name = "John Doe", Email = "john@email.com" },
            new Member { Id = 2, Name = "Alice Smith", Email = "alice@email.com" },
        };

        Mock<IMemberRepository> memberRepositoryMock = new();
        memberRepositoryMock.Setup(repo => repo.GetMembers()).Returns(expectedMembers);

        var repository = memberRepositoryMock.Object;

        // Act
        var actualMembers = repository.GetMembers();

        // Assert
        Assert.NotNull(actualMembers);
        Assert.Equal(expectedMembers.Count, actualMembers.Count);

        for (int i = 0; i < expectedMembers.Count; ++i)
        {
            Assert.Equal(expectedMembers[i].Id, actualMembers[i].Id);
            Assert.Equal(expectedMembers[i].Name, actualMembers[i].Name);
            Assert.Equal(expectedMembers[i].Email, actualMembers[i].Email);
        }
    }
}