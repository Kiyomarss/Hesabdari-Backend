using Hesabdari_Core.DTO.Setting;

namespace ServiceContracts;

public interface ISettingGetterService
{
    Task<SettingsSlidesDto> GetSettingsSlides();

    Task<LogoResult> GetLogo();
}