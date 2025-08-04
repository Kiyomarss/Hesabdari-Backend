using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.Base;

namespace ServiceContracts
{
    public interface ITestimonialsAdderService
    {
        Task<ItemResult<TestimonialResult>> AddTestimonial(TestimonialRequest testimonialAddRequest);
    }
}
