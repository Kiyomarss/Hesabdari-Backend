using Entities;

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
}


public static class HeroSlideExtensions
{
    public static HeroSlideResponse ToHeroSlideResponse(this HeroSlide? heroSlide)
    {
        return new HeroSlideResponse()
        {
            Id = heroSlide.Id, 
            Title = heroSlide.Title, 
            Link = heroSlide.Link, 
            Order = heroSlide.Order, 
            IsActive = heroSlide.IsActive, 
            ImageUrl = heroSlide.ImageUrl, 
            StartDate = heroSlide.StartDate, 
            EndDate = heroSlide.EndDate, 
            CreateAt = heroSlide.CreateAt
        };
    }
}