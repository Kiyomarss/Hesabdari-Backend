using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.Base;
using Hesabdari_Core.DTO.ConsultationRequest;

namespace ServiceContracts
{
    public interface IConsultationRequestsAdderService
    {
        Task AddConsultationRequest(CreateConsultationRequestDto consultationRequestAddRequest);
    }
}
