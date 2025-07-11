namespace ServiceContracts
{
 public interface IHeroSlidesDeleterService
 {
  Task<bool> DeleteHeroSlide(int heroSlideId);
 }
}
