using Hesabdari_Core.Domain.Entities;
using Hesabdari_Core.DTO.ConsultationRequest;

namespace RepositoryContracts;

public interface IConsultationRequestsRepository
{
    Task AddConsultationRequest(ConsultationRequest consultationRequest);

    Task UpdateConsultationRequest();

    Task<List<ConsultationRequest>> GetConsultationRequests(PaginationRequestDto dto);

    Task<int> GetConsultationRequestsCount(PaginationRequestDto dto);
    
    Task<List<ConsultationRequest>> GetStarredConsultationRequests();

    Task<int> GetUnreadCount();
    
    Task<ConsultationRequest?> FindConsultationRequestById(long id);
    
    Task<bool> DeleteConsultationRequests(List<long> list);
}