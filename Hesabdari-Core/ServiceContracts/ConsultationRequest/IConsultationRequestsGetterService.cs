using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.Base;
using Hesabdari_Core.DTO.ConsultationRequest;

namespace ServiceContracts
{
    public interface IConsultationRequestsGetterService
    {
        Task<ItemsResult<ConsultationRequestResultDto>> GetConsultationRequests();

        Task<ItemsResult<ConsultationRequestResultDto>> GetStarredConsultationRequests();
        
        Task<int> GetUnreadCount();
    }
}