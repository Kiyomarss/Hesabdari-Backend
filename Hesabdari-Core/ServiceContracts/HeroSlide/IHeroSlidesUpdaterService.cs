using Hesabdari_Core.DTO;

namespace ServiceContracts
{
 public interface IHeroSlidesUpdaterService
 {
  Task<GetHeroSlidesResult> UpdateHeroSlide(HeroSlideUpsertRequest heroSlideUpsertRequest);
 }
}