using Hesabdari_Core.DTO;

namespace ServiceContracts
{
    public interface IUserCoursesGetterService
    {
        Task<List<CourseSummaryDto>> FindCourseIdsByUserId();
    }
}