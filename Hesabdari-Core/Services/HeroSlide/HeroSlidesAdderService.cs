using Hesabdari_Core.DTO;
using Hesabdari_Core.ServiceContracts;
using Hesabdari_Core.ServiceContracts.Storage;
using Hesabdari_Core.Utils;
using ServiceContracts;
using RepositoryContracts;
using Microsoft.Extensions.Logging;

namespace Services
{
 public class HeroSlidesAdderService : IHeroSlidesAdderService
 {
  private readonly IHeroSlidesRepository _heroSlidesRepository;
  private readonly IImageStorageService _imageStorageService;
  private readonly IUnitOfWork _unitOfWork;
  private readonly ILogger<HeroSlidesGetterService> _logger;

  public HeroSlidesAdderService(
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

  public async Task AddHeroSlide(HeroSlideUpsertRequest heroSlideAddRequest)
  {
   var heroSlideById = await _heroSlidesRepository.FindHeroSlideById(heroSlideAddRequest.Id);
   
   if (heroSlideById == null)
    throw new InvalidOperationException("HeroSlide with the given ID does not exist.");

   if (heroSlideAddRequest.Image != null)
    heroSlideById.ImageUrl = await _imageStorageService.SaveImageAsync(heroSlideAddRequest.Image);
   
   if (heroSlideAddRequest.StartDate != null)
    heroSlideById.StartDate = DateTimeUtils.TryParsePersianDateTime(heroSlideAddRequest.StartDate);
   
   if (heroSlideAddRequest.EndDate != null)
    heroSlideById.EndDate = DateTimeUtils.TryParsePersianDateTime(heroSlideAddRequest.EndDate);
      
   heroSlideById.Title = heroSlideAddRequest.Title;
   heroSlideById.Link = heroSlideAddRequest.Link;
   heroSlideById.Order = heroSlideAddRequest.Order;
   heroSlideById.IsActive = heroSlideAddRequest.IsActive;
   heroSlideById.CreateAt = DateTime.Now;
   
   await _heroSlidesRepository.AddHeroSlide(heroSlideById);
  }
 }
}