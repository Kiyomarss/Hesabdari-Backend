using System.ComponentModel.DataAnnotations;

namespace Hesabdari_Core.Domain.Entities;

public class Course
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; }

    public string ShortDescription { get; set; }

    public string FullDescription { get; set; }

    public long Price { get; set; }

    public string ImageUrl { get; set; }

    public string IntroVideoUrl { get; set; }
        
    public int Order { get; set; }
    
    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();
}