using Hesabdari_Core.DTO;

namespace ServiceContracts
{
    public interface IUserCoursesAdderService
    {
        Task<ItemResult<TestimonialResult>> AddTestimonial(TestimonialRequest testimonialAddRequest);
    }
}
