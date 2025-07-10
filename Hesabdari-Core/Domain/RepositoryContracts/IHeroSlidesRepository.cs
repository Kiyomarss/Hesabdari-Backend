using Entities;
using Hesabdari_Core.DTO;

namespace RepositoryContracts;

public interface IHeroSlidesRepository
{
    Task<HeroSlide> AddHeroSlide(HeroSlide heroSlide);
    
    Task<List<HeroSlide>> GetHeroSlides();
    
    Task<HeroSlide?> FindHeroSlideById(Guid heroSlideId);

    Task<bool> DeleteHeroSlide(Guid heroSlideId);

    Task<HeroSlide> UpdateHeroSlide(HeroSlideUpsertRequest heroSlideUpsertRequest);
}