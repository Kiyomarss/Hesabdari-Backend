using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.Base;

namespace ServiceContracts
{
    public interface ITestimonialsUpdaterService
    {
        Task<ItemResult<TestimonialResult>> UpdateTestimonial(TestimonialRequest testimonialUpdateRequest);

        Task RemoveImageTestimonial(int testimonialId);

        Task<ItemResult<string>> UpdateImageTestimonial(FileUploadDto dto);
    }
}