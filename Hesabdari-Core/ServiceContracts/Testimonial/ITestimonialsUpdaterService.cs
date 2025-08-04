using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.Base;

namespace ServiceContracts
{
    public interface ITestimonialsUpdaterService
    {
        Task<ItemResult<TestimonialResult>> UpdateTestimonial(TestimonialRequest testimonialUpdateRequest);

        Task DeleteImageTestimonial(int testimonialId);
    }
}