using System.ComponentModel.DataAnnotations;

namespace Hesabdari_Core.Domain.Entities;

public class Chapter
{
    [Key]
    public int Id { get; set; }
    
    public string Title { get; set; } = null!;

    public int Order { get; set; }
    public int CourseId { get; set; }

    public Course Course { get; set; } = null!;

    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}