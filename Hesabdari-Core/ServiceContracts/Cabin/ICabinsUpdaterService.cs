using ContactsManager.Core.DTO;
using Hesabdari_Core.DTO;

namespace ServiceContracts
{
 public interface ICabinsUpdaterService
 {
  Task<CabinResponse> UpdateCabin(CabinUpsertRequest cabinUpsertRequest);
 }
}