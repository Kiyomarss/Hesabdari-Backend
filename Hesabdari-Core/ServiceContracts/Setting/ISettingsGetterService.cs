using ContactsManager.Core.DTO;
using Entities;
using Hesabdari_Core.DTO;

namespace ServiceContracts;

public interface ISettingGetterService
{
    Task<Setting> GetSetting();
}