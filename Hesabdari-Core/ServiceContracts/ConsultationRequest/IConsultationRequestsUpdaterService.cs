
namespace ServiceContracts
{
    public interface IConsultationRequestsUpdaterService
    {
        Task SetStarredStatus(long id);
    }
}