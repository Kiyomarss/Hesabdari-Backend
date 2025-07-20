using Hesabdari_Core.DTO.Setting;

namespace ServiceContracts
{
 public interface ISettingUpdaterService
 {
  Task<SettingsSlidesResult> UpdateSettingsSlides(SettingsSlidesRequest dto);
  
  Task<LogoResult> UpdateLogo(LogoRequest result);
 }
}