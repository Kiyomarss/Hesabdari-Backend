using Hesabdari_Core.DTO;

namespace ServiceContracts
{
    public interface ICoursesAdderService
    {
        Task<ItemResult<CourseResult>> AddCourse(CourseRequest courseAddRequest);
    }
}
