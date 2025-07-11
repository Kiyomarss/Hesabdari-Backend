using ContactsManager.Core.DTO;
using Hesabdari_Core.DTO;

namespace ServiceContracts;

public interface IHeroSlidesGetterService
{
    Task<HeroSlideResponse?> GetHeroSlideByHeroSlideId(int heroSlideId);
    
    Task<List<HeroSlideResponse>> GetHeroSlides();
}