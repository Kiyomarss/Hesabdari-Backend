using ServiceContracts;
using Hesabdari_Core.DTO.Setting;
using RepositoryContracts;
using Microsoft.Extensions.Logging;

namespace Services
{
 public class SettingGetterService : ISettingGetterService
 {
  //private field
  private readonly ISettingRepository _settingRepository;
  private readonly ILogger<SettingGetterService> _logger;

  public SettingGetterService(ISettingRepository settingRepository, ILogger<SettingGetterService> logger)
  {
   _settingRepository = settingRepository;
   _logger = logger;
  }
  
  public virtual async Task<SettingResult> GetSetting()
  {
   var setting = await _settingRepository.GetSetting();
    
   if (setting == null)
   {
    throw new InvalidOperationException("No settings found");
   }

   return new SettingResult(setting.IsSlideAutoChangeEnabled, setting.SlideIntervalInSeconds, setting.LogoImageUrl);
  }

 }
}
