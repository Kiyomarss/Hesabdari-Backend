using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.Base;

namespace ServiceContracts
{
    public interface ITestimonialsGetterService
    {
        Task<ItemsResult<TestimonialResult>> GetTestimonials();

        Task<ItemsResult<TestimonialDashboardResult>> GetDashboardTestimonials();
    }
}