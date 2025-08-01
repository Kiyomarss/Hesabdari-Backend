using Hesabdari_Core.Domain.Entities;
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

  public async Task<GetHeroSlidesResult> AddHeroSlide(HeroSlideUpsertRequest heroSlideAddRequest)
  {
   var heroSlide = new HeroSlide();

   if (heroSlideAddRequest.ImageDesktop != null)
   {
    heroSlide.ImageDesktopJpgUrl = await _imageStorageService.SaveImageAsync(heroSlideAddRequest.ImageDesktop);
    
    heroSlide.ImageDesktopWebpUrl = await _imageStorageService.ConvertToWebpAsync(heroSlideAddRequest.ImageDesktop);
   }
   
   if (heroSlideAddRequest.ImageMobile != null)
   {
    heroSlide.ImageMobileJpgUrl = await _imageStorageService.SaveImageAsync(heroSlideAddRequest.ImageMobile);
    
    heroSlide.ImageMobileWebpUrl = await _imageStorageService.ConvertToWebpAsync(heroSlideAddRequest.ImageMobile);
   }
   
   if (heroSlideAddRequest.StartDate != null)
    heroSlide.StartDate = DateTimeUtils.TryParsePersianDate(heroSlideAddRequest.StartDate);
   
   if (heroSlideAddRequest.EndDate != null)
    heroSlide.EndDate = DateTimeUtils.TryParsePersianDate(heroSlideAddRequest.EndDate);
      
   heroSlide.Title = heroSlideAddRequest.Title;
   //heroSlideById.Link = heroSlideAddRequest.Link;
   heroSlide.Order = heroSlideAddRequest.Order;
   heroSlide.IsActive = heroSlideAddRequest.IsActive;
   heroSlide.CreateAt = DateTime.Now;
   
   var slide  = await _heroSlidesRepository.AddHeroSlide(heroSlide);

   return new GetHeroSlidesResult(slide.Id, slide.Title, slide.ImageMobileJpgUrl, slide.Order, slide.IsActive, slide.StartDate.ToPersianDate(), slide.EndDate.ToPersianDate());
  }
 }
}