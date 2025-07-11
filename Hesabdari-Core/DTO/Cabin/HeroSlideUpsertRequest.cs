using Entities;
using Microsoft.AspNetCore.Http;

namespace Hesabdari_Core.DTO;

public class HeroSlideUpsertRequest
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string Link { get; set; }
    
    public int Order { get; set; }
    
    public bool IsActive { get; set; }
    
    public DateTime? StartDate { get; set; }
        
    public DateTime? EndDate { get; set; }
    
    public IFormFile?  Image { get; set; }
    
    public string? ImageUrl { get; set; }

    public HeroSlide ToHeroSlide()
    {
        return new HeroSlide
        {
            Title = Title,
            Link = Link,
            Order = Order,
            IsActive = IsActive,
            StartDate = StartDate,
            ImageUrl = ImageUrl
        };
    }
}