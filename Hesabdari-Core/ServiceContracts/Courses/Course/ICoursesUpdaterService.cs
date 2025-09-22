using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.Base;

namespace ServiceContracts
{
    public interface ICoursesUpdaterService
    {
        Task<ItemResult<TestimonialResult>> UpdateTestimonial(TestimonialRequest testimonialUpdateRequest);

        Task RemoveImageTestimonial(int testimonialId);

        Task<ItemResult<FileUpdateResult>> UpdateImageTestimonial(FileUploadDto dto);
    }
}