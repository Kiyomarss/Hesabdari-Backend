using Hesabdari_Core.DTO.Setting;
using Hesabdari_Core.ServiceContracts;
using Hesabdari_Core.ServiceContracts.Storage;
using ServiceContracts;
using RepositoryContracts;
using Microsoft.Extensions.Logging;

namespace Services
{
 public class SettingUpdaterService : ISettingUpdaterService
 {
  private readonly ISettingRepository _settingRepository;
  private readonly IImageStorageService _imageStorageService;
  private readonly IUnitOfWork _unitOfWork;
  private readonly ILogger<SettingGetterService> _logger;

  public SettingUpdaterService(
   ISettingRepository settingRepository,
   IImageStorageService imageStorageService,
   IUnitOfWork unitOfWork,
   ILogger<SettingGetterService> logger)
  {
   _settingRepository = settingRepository;
   _imageStorageService = imageStorageService;
   _unitOfWork = unitOfWork;
   _logger = logger;
  }

  public async Task UpdateSetting(SettingUpdateRequest dto)
  {
   if (dto == null)
    throw new ArgumentNullException(nameof(dto));

   var setting = await _settingRepository.GetSetting();
   
   setting.IsSlideAutoChangeEnabled = dto.IsSlideAutoChangeEnabled;

   setting.SlideIntervalInSeconds = !setting.IsSlideAutoChangeEnabled ? null : dto.SlideIntervalInSeconds;
   
   if (dto.Image != null)
   {
     await _imageStorageService.DeleteOldImage(setting.LogoImageUrl);

     setting.LogoImageUrl = await _imageStorageService.SaveImageAsync(dto.Image);
   }

   await _settingRepository.UpdateSetting(setting);
  }
 }
}