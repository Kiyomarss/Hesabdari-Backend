using Entities;

namespace Hesabdari_Core.DTO;

public class HeroSlideResponse
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public int MaxCapacity { get; set; }
    
    public int RegularPrice { get; set; }
    
    public int Discount { get; set; }
    
    public string Description { get; set; }
    
    public string? ImagePath { get; set; }
    
    public DateTime CreateAt { get; set; }
}


public static class HeroSlideExtensions
{
    public static HeroSlideResponse ToHeroSlideResponse(this HeroSlide? heroSlide)
    {
        return new HeroSlideResponse()
        {
            Id = heroSlide.Id, 
            Name = heroSlide.Name, 
            MaxCapacity = heroSlide.MaxCapacity, 
            RegularPrice = heroSlide.RegularPrice, 
            Discount = heroSlide.Discount, 
            ImagePath = heroSlide.ImagePath, 
            Description = heroSlide.Description, 
            CreateAt = heroSlide.CreateAt
        };
    }
}