using Hesabdari_Core.DTO;
using Hesabdari_Core.ServiceContracts;
using ServiceContracts;
using RepositoryContracts;
using Microsoft.Extensions.Logging;

namespace Services
{
 public class HeroSlidesAdderService : IHeroSlidesAdderService
 {
  private readonly IHeroSlidesRepository _heroSlidesRepository;
  private readonly IUnitOfWork _unitOfWork;
  private readonly ILogger<HeroSlidesGetterService> _logger;

  public HeroSlidesAdderService(
   IHeroSlidesRepository heroSlidesRepository,
   IUnitOfWork unitOfWork,
   ILogger<HeroSlidesGetterService> logger)
  {
   _heroSlidesRepository = heroSlidesRepository;
   _unitOfWork = unitOfWork;
   _logger = logger;
  }

  public async Task<HeroSlideResponse> AddHeroSlide(HeroSlideUpsertRequest heroSlideAddRequest)
  {
   ArgumentNullException.ThrowIfNull(heroSlideAddRequest);

   var heroSlide = heroSlideAddRequest.ToHeroSlide();

   heroSlide.Id = Guid.NewGuid();

   return await _unitOfWork.ExecuteTransactionAsync(async () =>
   {
    heroSlide = await _heroSlidesRepository.AddHeroSlide(heroSlide);

    return heroSlide.ToHeroSlideResponse();
   });
  }
 }
}