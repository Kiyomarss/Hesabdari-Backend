using Hesabdari_Core.DTO;

namespace ServiceContracts
{
    public interface ITestimonialsAdderService
    {
        Task<ItemResult<TestimonialResult>> AddTestimonial(TestimonialRequest testimonialAddRequest);
    }
}
