using ContactsManager.Core.DTO;
using Hesabdari_Core.DTO;

namespace ServiceContracts
{
 public interface IHeroSlidesAdderService
 {
  Task<GetHeroSlidesResult> AddHeroSlide(HeroSlideUpsertRequest heroSlideUpsertRequest);
 }
}