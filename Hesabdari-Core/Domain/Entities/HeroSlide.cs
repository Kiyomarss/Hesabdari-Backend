using System.ComponentModel.DataAnnotations;
using Hesabdari_Core.Domain.Entities;

namespace Entities;

public class HeroSlide
{
    [Key]
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string ImageUrl { get; set; }
    
    public string Link { get; set; }
    
    public int Order { get; set; }
    
    public bool IsActive { get; set; }
    
    public DateTime? StartDate { get; set; }
    
    public DateTime? EndDate { get; set; }
    
    public DateTime CreateAt { get; set; }
}