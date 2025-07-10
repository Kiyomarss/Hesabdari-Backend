using Entities;
using Hesabdari_Core.DTO;
using Hesabdari_Core.ServiceContracts;
using ServiceContracts;
using RepositoryContracts;
using Microsoft.Extensions.Logging;

namespace Services
{
 public class HeroSlidesUpdaterService : IHeroSlidesUpdaterService
 {
  private readonly IHeroSlidesRepository _heroSlidesRepository;
  private readonly IUnitOfWork _unitOfWork;
  private readonly ILogger<HeroSlidesGetterService> _logger;

  public HeroSlidesUpdaterService(
   IHeroSlidesRepository heroSlidesRepository,
   IUnitOfWork unitOfWork,
   ILogger<HeroSlidesGetterService> logger)
  {
   _heroSlidesRepository = heroSlidesRepository;
   _unitOfWork = unitOfWork;
   _logger = logger;
  }

  public async Task<HeroSlideResponse> UpdateHeroSlide(HeroSlideUpsertRequest heroSlideUpdateRequest)
  {
   ArgumentNullException.ThrowIfNull(heroSlideUpdateRequest);

   return await _unitOfWork.ExecuteTransactionAsync(async () =>
   {
    var updatedHeroSlide = await _heroSlidesRepository.UpdateHeroSlide(heroSlideUpdateRequest);
    return updatedHeroSlide.ToHeroSlideResponse();
   });
  }
 }
}