using Hesabdari_Core.DTO.Setting;

namespace ServiceContracts;

public interface ISettingGetterService
{
    Task<SettingResult> GetSetting();
}