using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models.Repositories.Entities.Classes;

public class Question
{
    public Question()
    {
    }

    public int Id { get; set; }

    [Column("Question")] public string? QuestionText { get; set; }

    public int LessonId { get; set; }

    public int MemberId { get; set; }

    public int TimeCodeId { get; set; }
}