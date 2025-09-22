using Hesabdari_Core.DTO;

namespace ServiceContracts
{
    public interface IUserCoursesGetterService
    {
        Task<ItemsResult<TestimonialResult>> GetTestimonials();

        Task<ItemsResult<TestimonialDashboardResult>> GetDashboardTestimonials();
    }
}