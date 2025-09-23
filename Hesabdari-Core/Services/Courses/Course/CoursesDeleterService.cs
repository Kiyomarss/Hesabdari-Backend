using Hesabdari_Core.ServiceContracts.Storage;
using ServiceContracts;
using RepositoryContracts;

namespace Services
{
    public class CoursesDeleterService : ICoursesDeleterService
    {
        private readonly ICoursesRepository _coursesRepository;
        private readonly IImageStorageService _imageStorageService;
        private readonly IVideoStorageService _videoStorageService;

        //constructor
        public CoursesDeleterService(
            ICoursesRepository coursesRepository,
            IImageStorageService imageStorageService,
            IVideoStorageService videoStorageService
        )
        {
            _coursesRepository = coursesRepository;
            _imageStorageService = imageStorageService;
            _videoStorageService = videoStorageService;
        }

        public async Task DeleteCourse(int courseId)
        {
            var course = await _coursesRepository.FindCourseById(courseId);

            if (course == null)
                throw new KeyNotFoundException($"course with ID {courseId} does not exist.");

            await _imageStorageService.DeleteOldImagesAsync(course.ImageUrl);
            await _videoStorageService.DeleteOldVideosAsync(course.IntroVideoUrl);

            var lessonVideoPaths = course.Chapters
                                         .SelectMany(ch => ch.Lessons)
                                         .Select(l => l.VideoUrl)
                                         .ToArray();

            foreach (var videoUrl in lessonVideoPaths)
            {
                await _videoStorageService.DeleteOldVideosAsync(videoUrl);
            }

            await _coursesRepository.DeleteCourse(courseId);
        }
    }
}