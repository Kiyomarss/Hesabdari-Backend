using ServiceContracts;
using RepositoryContracts;

namespace Services
{
    public class ConsultationRequestsDeleterService : IConsultationRequestsDeleterService
    {
        private readonly IConsultationRequestsRepository _consultationRequestsRepository;

        //constructor
        public ConsultationRequestsDeleterService(
            IConsultationRequestsRepository consultationRequestsRepository
        )
        {
            _consultationRequestsRepository = consultationRequestsRepository;
        }

        public async Task DeleteConsultationRequests(List<long> ids)
        {
            foreach (var id in ids)
            {
                var consultationRequest = await _consultationRequestsRepository.FindConsultationRequestById(id);

                if (consultationRequest == null)
                    throw new KeyNotFoundException($"consultationRequest with ID {id} does not exist.");
            }
            
            await _consultationRequestsRepository.DeleteConsultationRequests(ids);
        }
    }
}