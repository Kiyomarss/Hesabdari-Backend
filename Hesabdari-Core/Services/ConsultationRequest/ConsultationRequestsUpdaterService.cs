using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.Base;
using Hesabdari_Core.ServiceContracts.Storage;
using ServiceContracts;
using RepositoryContracts;

namespace Services
{
    public class ConsultationRequestsUpdaterService : IConsultationRequestsUpdaterService
    {
        private readonly IConsultationRequestsRepository _consultationRequestsRepository;
        
        public ConsultationRequestsUpdaterService(
            IConsultationRequestsRepository consultationRequestRepository)
        {
            _consultationRequestsRepository = consultationRequestRepository;
        }
        
        public async Task SetStarredStatus(long id)
        {
            var consultationRequest = await _consultationRequestsRepository.FindConsultationRequestById(id);

            if (consultationRequest == null)
                throw new KeyNotFoundException($"consultationRequest with ID {id} does not exist.");
            
            consultationRequest.IsStarred = !consultationRequest.IsStarred;

            await _consultationRequestsRepository.UpdateConsultationRequest();
        }
    }
}