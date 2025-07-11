using Entities;
using Hesabdari_Core.DTO;

namespace RepositoryContracts;

public interface IHeroSlidesRepository
{
    Task<HeroSlide> AddHeroSlide(HeroSlide heroSlide);

    Task<List<string>> GetHeroSlidesImageUrl();
    Task<List<HeroSlide>> GetHeroSlides();
    
    Task<HeroSlide?> FindHeroSlideById(int heroSlideId);

    Task<bool> DeleteHeroSlide(int heroSlideId);

    Task<HeroSlide> UpdateHeroSlide(HeroSlide heroSlide);
}