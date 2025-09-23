using ServiceContracts;
using Hesabdari_Core.DTO;
using RepositoryContracts;

namespace Services
{
    public class CoursesGetterService : ICoursesGetterService
    {
        private readonly ICoursesRepository _coursesRepository;

        public CoursesGetterService(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        public virtual async Task<ItemsResult<CourseSummaryDto>> GetCourses()
        {
            var courses = await _coursesRepository.GetCoursesAsync();

            return new ItemsResult<CourseSummaryDto>(courses);
        }

        public virtual async Task<ItemResult<CourseResultDto>> GetCourseById(int id)
        {
            var courses = await _coursesRepository.GetCourseByIdAsync(id);

            return new ItemResult<CourseResultDto>(courses);

        }
    }
}