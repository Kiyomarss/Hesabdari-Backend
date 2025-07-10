using ContactsManager.Core.DTO;
using Hesabdari_Core.DTO;

namespace ServiceContracts
{
 public interface ICabinsAdderService
 {
  Task<CabinResponse> AddCabin(CabinUpsertRequest cabinUpsertRequest);
 }
}