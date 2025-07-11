using ContactsManager.Core.DTO;
using Hesabdari_Core.Domain.Entities;
using Hesabdari_Core.DTO;

namespace ServiceContracts
{
 public interface ISettingUpdaterService
 {
  Task<Setting> UpdateSetting(Setting setting);
 }
}