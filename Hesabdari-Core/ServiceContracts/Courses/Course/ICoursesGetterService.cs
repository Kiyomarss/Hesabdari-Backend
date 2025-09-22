using Hesabdari_Core.DTO;

namespace ServiceContracts
{
    public interface ICoursesGetterService
    {
        Task<ItemsResult<TestimonialResult>> GetTestimonials();

        Task<ItemsResult<TestimonialDashboardResult>> GetDashboardTestimonials();
    }
}