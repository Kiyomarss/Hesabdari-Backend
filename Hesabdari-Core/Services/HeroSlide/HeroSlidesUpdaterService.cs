using Hesabdari_Core.DTO;
using Hesabdari_Core.ServiceContracts;
using Hesabdari_Core.ServiceContracts.Storage;
using Hesabdari_Core.Utils;
using ServiceContracts;
using RepositoryContracts;
using Microsoft.Extensions.Logging;

namespace Services
{
 public class HeroSlidesUpdaterService : IHeroSlidesUpdaterService
 {
  private readonly IHeroSlidesRepository _heroSlidesRepository;
  private readonly IImageStorageService _imageStorageService;
  private readonly IUnitOfWork _unitOfWork;
  private readonly ILogger<HeroSlidesGetterService> _logger;

  public HeroSlidesUpdaterService(
   IHeroSlidesRepository heroSlidesRepository,
   IImageStorageService imageStorageService,
   IUnitOfWork unitOfWork,
   ILogger<HeroSlidesGetterService> logger)
  {
   _heroSlidesRepository = heroSlidesRepository;
   _imageStorageService = imageStorageService;
   _unitOfWork = unitOfWork;
   _logger = logger;
  }

  public async Task<GetHeroSlidesResult> UpdateHeroSlide(HeroSlideUpsertRequest heroSlideUpdateRequest)
  {
   if (heroSlideUpdateRequest == null)
    throw new InvalidOperationException("HeroSlide with the given ID does not exist.");
   
   var heroSlide = await _heroSlidesRepository.FindHeroSlideById(heroSlideUpdateRequest.Id);
   
   if (heroSlide == null)
    throw new InvalidOperationException("HeroSlide with the given ID does not exist.");

   if (heroSlideUpdateRequest.Image != null)
   {
    if (!await _heroSlidesRepository.HasMultipleHeroSlidesWithImage(heroSlide.ImageUrl))
     await _imageStorageService.DeleteOldImage(heroSlide.ImageUrl);

    var newImageUrl = await _imageStorageService.SaveImageAsync(heroSlideUpdateRequest.Image);
    heroSlide.ImageUrl = newImageUrl;
   }

   heroSlide.Title = heroSlideUpdateRequest.Title;
   //heroSlideById.Link = "Link";
   heroSlide.Order = heroSlideUpdateRequest.Order;
   heroSlide.IsActive = heroSlideUpdateRequest.IsActive;

   if (heroSlideUpdateRequest.StartDate != null)
    heroSlide.StartDate = DateTimeUtils.TryParsePersianDateTime(heroSlideUpdateRequest.StartDate);
   if (heroSlideUpdateRequest.EndDate != null)
    heroSlide.EndDate = DateTimeUtils.TryParsePersianDateTime(heroSlideUpdateRequest.EndDate);

   await _heroSlidesRepository.UpdateHeroSlide();

   return new GetHeroSlidesResult(heroSlide.Id, heroSlide.Title, heroSlide.ImageUrl, heroSlide.Order, heroSlide.IsActive, heroSlide.StartDate.ToPersianDate(), heroSlide.EndDate.ToPersianDate());
  }
 }
}