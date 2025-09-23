using Hesabdari_Core.DTO;

namespace ServiceContracts
{
    public interface ICoursesGetterService
    {
        Task<ItemsResult<CourseSummaryDto>> GetCourses();

        Task<ItemResult<CourseResultDto>> GetCourseById(int id);
    }
}