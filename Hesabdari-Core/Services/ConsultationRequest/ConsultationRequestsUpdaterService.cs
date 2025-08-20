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
        
        public async Task MarkConsultationAsRead(long id)
        {
            var consultationRequest = await _consultationRequestsRepository.FindConsultationRequestById(id);

            if (consultationRequest == null)
                throw new KeyNotFoundException($"consultationRequest with ID {id} does not exist.");
            
            consultationRequest.IsRead = true;

            await _consultationRequestsRepository.UpdateConsultationRequest();
        }
    }
}