using Hesabdari_Core.Domain.Entities;
using Hesabdari_Core.DTO;

namespace RepositoryContracts;

public interface IUserCoursesRepository
{
    Task<UserCourse> AddUserCourse(UserCourse userCourse);

    Task<UserCourse?> FindUserCourse(int courseId, Guid userId);
    
    Task<List<UserCourse>> GetUserCourses();

    Task<List<CourseSummaryDto>> FindCourseIdsByUserId(Guid userId);
    Task<bool> DeleteUserCourseAsync(int userCourseId);
}