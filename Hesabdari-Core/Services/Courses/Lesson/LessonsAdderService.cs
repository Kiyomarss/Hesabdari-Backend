using Hesabdari_Core.Domain.Entities;
using Hesabdari_Core.DTO;
using Hesabdari_Core.ServiceContracts.Storage;
using ServiceContracts;
using RepositoryContracts;

namespace Services
{
    public class LessonsAdderService : ILessonsAdderService
    {
        private readonly ILessonsRepository _lessonsRepository;

        public LessonsAdderService(
            ILessonsRepository lessonsRepository
        )
        {
            _lessonsRepository = lessonsRepository;
        }

        public async Task<ItemResult<LessonResult>> AddLesson(LessonRequest lessonAddRequest)
        {
            var lesson = new Lesson();

            lesson.Title = lessonAddRequest.Title;
            lesson.Order = lessonAddRequest.Order;
            lesson.IsFree = lessonAddRequest.IsFree;

            await _lessonsRepository.AddLesson(lesson);

            return new ItemResult<LessonResult>(new LessonResult(lesson.Id, lesson.Title, lesson.Order, lesson.IsFree));
        }
    }
}