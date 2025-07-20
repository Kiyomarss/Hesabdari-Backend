using Hesabdari_Core.DTO.Setting;

namespace ServiceContracts
{
 public interface ISettingUpdaterService
 {
  Task<SettingsSlidesDto> UpdateSettingsSlides(SettingsSlidesDto dto);
  
  Task<LogoResult> UpdateLogo(LogoRequest result);
 }
}