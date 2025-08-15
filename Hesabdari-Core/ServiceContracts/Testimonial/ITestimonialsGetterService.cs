using Hesabdari_Core.DTO;

namespace ServiceContracts
{
    public interface ITestimonialsGetterService
    {
        Task<ItemsResult<TestimonialResult>> GetTestimonials();

        Task<ItemsResult<TestimonialDashboardResult>> GetDashboardTestimonials();
    }
}