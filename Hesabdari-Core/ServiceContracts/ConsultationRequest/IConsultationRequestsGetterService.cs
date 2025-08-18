using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.ConsultationRequest;

namespace ServiceContracts
{
    public interface IConsultationRequestsGetterService
    {
        Task<ItemsResult<ConsultationRequestResultDto>> GetConsultationRequests(PaginationRequestDto dto);

        Task<ItemsResult<ConsultationRequestResultDto>> GetStarredConsultationRequests();

        Task<ItemResult<int>> GetUnreadCount();
    }
}