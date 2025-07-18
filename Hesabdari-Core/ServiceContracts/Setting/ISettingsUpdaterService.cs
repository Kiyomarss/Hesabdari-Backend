using Hesabdari_Core.DTO.Setting;

namespace ServiceContracts
{
 public interface ISettingUpdaterService
 {
  Task UpdateSetting(SettingUpdateRequest dto);
 }
}