using ContactsManager.Core.DTO;
using Hesabdari_Core.DTO;

namespace ServiceContracts
{
 public interface IHeroSlidesUpdaterService
 {
  Task<HeroSlideResponse> UpdateHeroSlide(HeroSlideUpsertRequest heroSlideUpsertRequest);
 }
}