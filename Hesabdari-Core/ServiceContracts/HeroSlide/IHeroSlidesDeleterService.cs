namespace ServiceContracts
{
 public interface IHeroSlidesDeleterService
 {
  Task<bool> DeleteHeroSlide(Guid heroSlideId);
 }
}
