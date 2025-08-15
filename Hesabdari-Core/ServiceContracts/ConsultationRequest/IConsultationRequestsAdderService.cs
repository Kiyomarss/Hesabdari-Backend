using Hesabdari_Core.DTO.ConsultationRequest;

namespace ServiceContracts
{
    public interface IConsultationRequestsAdderService
    {
        Task AddConsultationRequest(CreateConsultationRequestDto consultationRequestAddRequest);
    }
}
