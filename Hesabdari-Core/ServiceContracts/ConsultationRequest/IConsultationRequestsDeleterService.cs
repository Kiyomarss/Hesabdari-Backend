namespace ServiceContracts
{
    public interface IConsultationRequestsDeleterService
    {
        Task DeleteConsultationRequests(List<long> ids);
    }    
}