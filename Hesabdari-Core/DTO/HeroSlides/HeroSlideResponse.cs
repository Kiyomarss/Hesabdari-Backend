using Hesabdari_Core.Domain.Entities;

namespace Hesabdari_Core.DTO;

public class HeroSlideResponse
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string ImageUrl { get; set; }
    
    public string Link { get; set; }
    
    public int Order { get; set; }
    
    public bool IsActive { get; set; }
    
    public DateTime? StartDate { get; set; }
    
    public DateTime? EndDate { get; set; }
    
    public DateTime CreateAt { get; set; }
    
    public string RowVersion { get; set; }
}