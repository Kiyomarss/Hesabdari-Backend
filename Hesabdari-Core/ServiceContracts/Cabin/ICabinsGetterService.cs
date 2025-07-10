using ContactsManager.Core.DTO;
using Hesabdari_Core.DTO;

namespace ServiceContracts;

public interface ICabinsGetterService
{
    Task<CabinResponse?> GetCabinByCabinId(Guid cabinId);
    
    Task<List<CabinResponse>> GetCabins();
}