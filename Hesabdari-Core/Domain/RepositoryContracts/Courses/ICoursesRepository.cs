using Hesabdari_Core.Domain.Entities;
using Hesabdari_Core.DTO;

namespace RepositoryContracts;

public interface ICoursesRepository
{
    Task<Course> AddCourse(Course course);

    Task UpdateCourse();

    Task<Course?> FindCourseById(int courseId);

    Task<List<CourseSummaryDto>> GetCoursesAsync();

    Task<bool> DeleteCourse(int courseId);
}