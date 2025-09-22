using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.Base;
using Hesabdari_Core.ServiceContracts.Storage;
using ServiceContracts;
using RepositoryContracts;

namespace Services
{
    public class LessonsUpdaterService : ILessonsUpdaterService
    {
        private readonly ILessonsRepository _lessonsRepository;
        private readonly IVideoStorageService _videoStorageService;

        public LessonsUpdaterService(
            ILessonsRepository lessonRepository,
            IVideoStorageService videoStorageService)
        {
            _lessonsRepository = lessonRepository;
            _videoStorageService = videoStorageService;
        }

        public async Task<ItemResult<LessonResult>> UpdateLesson(LessonRequest lessonUpdateRequest)
        {
            if (lessonUpdateRequest == null)
                throw new InvalidOperationException("Lesson with the given ID does not exist.");

            var lesson = await _lessonsRepository.FindLessonById((int)lessonUpdateRequest.Id);

            if (lesson == null)
                throw new InvalidOperationException("Lesson with the given ID does not exist.");

            lesson.Title = lessonUpdateRequest.Title;
            lesson.Order = lessonUpdateRequest.Order;
            lesson.IsFree = lessonUpdateRequest.IsFree;

            await _lessonsRepository.UpdateLesson();

            return new ItemResult<LessonResult>(new LessonResult(lesson.Id, lesson.Title, lesson.Order, lesson.IsFree));
        }

        public async Task RemoveVideoLesson(int lessonId)
        {
            var lesson = await _lessonsRepository.FindLessonById(lessonId);

            if (lesson == null)
                throw new KeyNotFoundException($"lesson with ID {lessonId} does not exist.");

            await _videoStorageService.DeleteOldVideosAsync(lesson.VideoUrl);

            lesson.VideoUrl = null;

            await _lessonsRepository.UpdateLesson();
        }
        
        public async Task<ItemResult<FileUpdateResult>> UpdateVideoLesson(FileUploadDto dto)
        {
            var lesson = await _lessonsRepository.FindLessonById(dto.Id);

            if (lesson == null)
                throw new KeyNotFoundException($"lesson with ID {dto.Id} does not exist.");

            await _videoStorageService.DeleteOldVideosAsync(lesson.VideoUrl);

            lesson.VideoUrl = await _videoStorageService.SaveVideoAsync(dto.Image);

            await _lessonsRepository.UpdateLesson();

            return new ItemResult<FileUpdateResult>(new FileUpdateResult(lesson.Id, lesson.VideoUrl));
        }
    }
}