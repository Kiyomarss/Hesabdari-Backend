using Entities;
using Microsoft.AspNetCore.Http;

namespace Hesabdari_Core.DTO;

public class HeroSlideUpsertRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public int MaxCapacity { get; set; }
    
    public int RegularPrice { get; set; }
    
    public int Discount { get; set; }
    
    public string Description { get; set; }
    
    public IFormFile?  Image { get; set; }
    
    public string? ImagePath { get; set; }

    public HeroSlide ToHeroSlide()
    {
        return new HeroSlide
        {
            Name = Name,
            MaxCapacity = MaxCapacity,
            RegularPrice = RegularPrice,
            Discount = Discount,
            Description = Description,
            ImagePath = ImagePath
        };
    }
}