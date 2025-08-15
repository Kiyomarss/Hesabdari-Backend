using Hesabdari_Core.Domain.Entities;
using Hesabdari_Core.DTO;

namespace RepositoryContracts;

public interface IConsultationRequestsRepository
{
    Task AddConsultationRequest(ConsultationRequest consultationRequest);

    Task UpdateConsultationRequest();

    Task<List<ConsultationRequest>> GetConsultationRequests();

    Task<List<ConsultationRequest>> GetStarredConsultationRequests();

    Task<int> GetUnreadCount();
    
    Task<ConsultationRequest?> FindConsultationRequestById(long id);
    
    Task<bool> DeleteConsultationRequests(List<long> list);
}