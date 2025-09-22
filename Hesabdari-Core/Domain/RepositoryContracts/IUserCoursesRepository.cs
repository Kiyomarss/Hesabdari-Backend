using Hesabdari_Core.Domain.Entities;

namespace RepositoryContracts;

public interface IUserCoursesRepository
{
    Task<UserCourse> AddUserCourse(UserCourse userCourse);

    Task<List<UserCourse>> GetUserCourses();
    
    Task<List<Course>> FindCoursesByUserId(Guid userId);

    Task<bool> DeleteUserCourseAsync(int courseId, Guid userId);
}