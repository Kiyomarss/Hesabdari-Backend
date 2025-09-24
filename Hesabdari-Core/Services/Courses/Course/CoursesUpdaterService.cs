using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.Base;
using Hesabdari_Core.ServiceContracts.Storage;
using ServiceContracts;
using RepositoryContracts;

namespace Services
{
    public class CoursesUpdaterService : ICoursesUpdaterService
    {
        private readonly ICoursesRepository _coursesRepository;
        private readonly IImageStorageService _imageStorageService;
        private readonly IVideoStorageService _videoStorageService;

        public CoursesUpdaterService(
            ICoursesRepository courseRepository,
            IImageStorageService imageStorageService,
            IVideoStorageService videoStorageService
        )
        {
            _coursesRepository = courseRepository;
            _imageStorageService = imageStorageService;
            _videoStorageService = videoStorageService;
        }

        public async Task<ItemResult<CourseResult>> UpdateCourse(CourseRequest courseUpdateRequest)
        {
            if (courseUpdateRequest == null)
                throw new InvalidOperationException("Course with the given ID does not exist.");

            var course = await _coursesRepository.FindCourseById((int)courseUpdateRequest.Id);

            if (course == null)
                throw new InvalidOperationException("Course with the given ID does not exist.");

            course.Title = courseUpdateRequest.Title;
            course.ShortDescription = courseUpdateRequest.ShortDescription;
            course.FullDescription = courseUpdateRequest.FullDescription;
            course.Price = courseUpdateRequest.Price;
            course.Order = courseUpdateRequest.Order;
            course.IsActive = courseUpdateRequest.IsActive;

            await _coursesRepository.UpdateCourse();

            return new ItemResult<CourseResult>(new CourseResult(course.Id, course.Title, course.ShortDescription, course.FullDescription, course.Price, course.Order, course.IsActive));
        }

        public async Task RemoveImageCourse(int courseId)
        {
            var course = await _coursesRepository.FindCourseById(courseId);

            if (course == null)
                throw new KeyNotFoundException($"course with ID {courseId} does not exist.");

            await _imageStorageService.DeleteOldImagesAsync(course.ImageUrl);

            course.ImageUrl = null;

            await _coursesRepository.UpdateCourse();
        }

        public async Task<ItemResult<FileUpdateResult>> UpdateImageCourse(FileUploadDto dto)
        {
            var course = await _coursesRepository.FindCourseById(dto.Id);

            if (course == null)
                throw new KeyNotFoundException($"course with ID {dto.Id} does not exist.");

            await _imageStorageService.DeleteOldImagesAsync(course.ImageUrl);

            course.ImageUrl = await _imageStorageService.SaveImageAsync(dto.Image);

            await _coursesRepository.UpdateCourse();

            return new ItemResult<FileUpdateResult>(new FileUpdateResult(course.Id, course.ImageUrl));
        }

        public async Task RemoveVideoCourse(int courseId)
        {
            var course = await _coursesRepository.FindCourseById(courseId);

            if (course == null)
                throw new KeyNotFoundException($"course with ID {courseId} does not exist.");

            await _videoStorageService.DeleteOldVideosAsync(course.IntroVideoUrl);

            course.IntroVideoUrl = null;

            await _coursesRepository.UpdateCourse();
        }

        public async Task<ItemResult<FileUpdateResult>> UpdateVideoCourse(FileUploadDto dto)
        {
            var course = await _coursesRepository.FindCourseById(dto.Id);

            if (course == null)
                throw new KeyNotFoundException($"course with ID {dto.Id} does not exist.");

            await _videoStorageService.DeleteOldVideosAsync(course.IntroVideoUrl);

            course.IntroVideoUrl = await _videoStorageService.SaveVideoAsync(dto.Image);

            await _coursesRepository.UpdateCourse();

            return new ItemResult<FileUpdateResult>(new FileUpdateResult(course.Id, course.ImageUrl));
        }
    }
}