using Hesabdari_Core.Domain.Entities;
using Hesabdari_Core.DTO.ConsultationRequest;
using ServiceContracts;
using RepositoryContracts;

namespace Services
{
    public class ConsultationRequestsAdderService : IConsultationRequestsAdderService
    {
        private readonly IConsultationRequestsRepository _consultationRequestsRepository;

        public ConsultationRequestsAdderService(
            IConsultationRequestsRepository consultationRequestsRepository
        )
        {
            _consultationRequestsRepository = consultationRequestsRepository;
        }

        public async Task AddConsultationRequest(CreateConsultationRequestDto consultationRequestAddRequest)
        {
            var consultationRequest = new ConsultationRequest();

            consultationRequest.FullName = consultationRequestAddRequest.FullName;
            consultationRequest.CompanyName = consultationRequestAddRequest.CompanyName;
            consultationRequest.Email = consultationRequestAddRequest.Email;
            consultationRequest.PhoneNumber = consultationRequestAddRequest.PhoneNumber;
            consultationRequest.Description = consultationRequestAddRequest.Description;
            consultationRequest.ServiceType = consultationRequestAddRequest.ServiceType;
            consultationRequest.CreateAt = DateTime.Now;
            consultationRequest.IsRead = false;
            consultationRequest.IsStarred = false;
            
            await _consultationRequestsRepository.AddConsultationRequest(consultationRequest);
        }
    }
}