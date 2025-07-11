using ContactsManager.Core.DTO;
using Hesabdari_Core.DTO;

namespace ServiceContracts;

public interface IHeroSlidesGetterService
{
    Task<GetHeroSlidesByIdResult> GetHeroSlideById(int heroSlideId);
    
    Task<List<GetHeroSlidesResult>> GetHeroSlides();

    Task<ImagesResponse> GetHeroSlidesImageUrl();
}