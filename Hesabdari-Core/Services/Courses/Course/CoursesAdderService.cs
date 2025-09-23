using Hesabdari_Core.Domain.Entities;
using Hesabdari_Core.DTO;
using Hesabdari_Core.ServiceContracts.Storage;
using ServiceContracts;
using RepositoryContracts;

namespace Services
{
    public class CoursesAdderService : ICoursesAdderService
    {
        private readonly ICoursesRepository _coursesRepository;

        public CoursesAdderService(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        public async Task<ItemResult<CourseResult>> AddCourse(CourseRequest courseAddRequest)
        {
            var course = new Course();

            course.Title = courseAddRequest.Title;
            course.ShortDescription = courseAddRequest.ShortDescription;
            course.FullDescription = courseAddRequest.FullDescription;
            course.Price = courseAddRequest.Price;
            course.Order = courseAddRequest.Order;
            course.IsActive = courseAddRequest.IsActive;

            await _coursesRepository.AddCourse(course);

            return new ItemResult<CourseResult>(new CourseResult(course.Id, course.Title, course.ShortDescription, course.FullDescription, course.Price, course.Order, course.IsActive));
        }
    }
}