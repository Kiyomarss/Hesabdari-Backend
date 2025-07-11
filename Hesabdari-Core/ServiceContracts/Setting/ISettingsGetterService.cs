using ContactsManager.Core.DTO;
using Hesabdari_Core.Domain.Entities;
using Hesabdari_Core.DTO;

namespace ServiceContracts;

public interface ISettingGetterService
{
    Task<Setting> GetSetting();
}