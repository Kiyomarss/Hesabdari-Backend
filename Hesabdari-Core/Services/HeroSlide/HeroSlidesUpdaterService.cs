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

  public async Task UpdateHeroSlide(HeroSlideUpsertRequest heroSlideUpdateRequest)
  {
   if (heroSlideUpdateRequest == null)
    throw new InvalidOperationException("HeroSlide with the given ID does not exist.");
   
   var heroSlideById = await _heroSlidesRepository.FindHeroSlideById(heroSlideUpdateRequest.Id);
   
   if (heroSlideById == null)
    throw new InvalidOperationException("HeroSlide with the given ID does not exist.");

   if (heroSlideUpdateRequest.Image != null)
   {
    await _imageStorageService.DeleteOldImage(heroSlideById.ImageUrl);
    
    heroSlideById.ImageUrl = await _imageStorageService.SaveImageAsync(heroSlideUpdateRequest.Image);
   }
   
   heroSlideById.Title = heroSlideUpdateRequest.Title;
   heroSlideById.Link = heroSlideUpdateRequest.Link;
   heroSlideById.Order = heroSlideUpdateRequest.Order;
   heroSlideById.IsActive = heroSlideUpdateRequest.IsActive;
   if (heroSlideUpdateRequest.StartDate != null)
    heroSlideById.StartDate = DateTimeUtils.TryParsePersianDateTime(heroSlideUpdateRequest.StartDate);
   if (heroSlideUpdateRequest.EndDate != null)
    heroSlideById.EndDate = DateTimeUtils.TryParsePersianDateTime(heroSlideUpdateRequest.EndDate);
   
   await _heroSlidesRepository.UpdateHeroSlide(heroSlideById);
  }
 }
}