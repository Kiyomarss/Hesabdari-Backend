using Hesabdari_Core.DTO;

namespace ServiceContracts
{
    public interface IUserCoursesAdderService
    {
        Task AddUserCourse(int courseId);
    }
}
