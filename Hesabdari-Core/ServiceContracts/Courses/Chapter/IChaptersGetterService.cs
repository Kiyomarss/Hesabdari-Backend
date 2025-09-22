using Hesabdari_Core.DTO;

namespace ServiceContracts
{
    public interface IChaptersGetterService
    {
        Task<ItemsResult<TestimonialResult>> GetTestimonials();

        Task<ItemsResult<TestimonialDashboardResult>> GetDashboardTestimonials();
    }
}