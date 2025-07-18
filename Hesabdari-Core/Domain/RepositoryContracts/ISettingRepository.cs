using Hesabdari_Core.Domain.Entities;

namespace RepositoryContracts;

public interface ISettingRepository
{
    Task<Setting> GetSetting();
    
    Task UpdateSetting(Setting setting);
}