using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.Base;

namespace ServiceContracts
{
    public interface ICoursesUpdaterService
    {
        Task<ItemResult<CourseResult>> UpdateCourse(CourseRequest courseUpdateRequest);
        Task RemoveImageCourse(int courseId);
        
        Task<ItemResult<FileUpdateResult>> UpdateImageCourse(FileUploadDto dto);

        Task RemoveVideoCourse(int courseId);

        Task<ItemResult<FileUpdateResult>> UpdateVideoCourse(FileUploadDto dto);
    }
}