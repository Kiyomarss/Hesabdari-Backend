using Hesabdari_Core.ServiceContracts.Storage;
using ServiceContracts;
using RepositoryContracts;

namespace Services
{
    public class LessonsDeleterService : ILessonsDeleterService
    {
        private readonly ILessonsRepository _lessonsRepository;
        private readonly IVideoStorageService _videoStorageService;

        //constructor
        public LessonsDeleterService(
            ILessonsRepository lessonsRepository,
            IVideoStorageService videoStorageService
        )
        {
            _lessonsRepository = lessonsRepository;
            _videoStorageService = videoStorageService;
        }

        public async Task DeleteLesson(int lessonId)
        {
            var lesson = await _lessonsRepository.FindLessonById(lessonId);

            if (lesson == null)
                throw new KeyNotFoundException($"lesson with ID {lessonId} does not exist.");

            await _videoStorageService.DeleteOldVideosAsync(lesson.VideoUrl);

            await _lessonsRepository.DeleteLesson(lessonId);
        }
    }
}