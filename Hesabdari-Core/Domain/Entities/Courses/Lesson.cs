using System.ComponentModel.DataAnnotations;

namespace Hesabdari_Core.Domain.Entities;

public class Lesson
{
    [Key]
    public int Id { get; set; }
    
    public string Title { get; set; }

    public string VideoUrl { get; set; }

    public TimeSpan Duration { get; set; }

    public int Order { get; set; }

    public bool IsFree { get; set; }

    public int ChapterId { get; set; }

    public Chapter Chapter { get; set; }
}