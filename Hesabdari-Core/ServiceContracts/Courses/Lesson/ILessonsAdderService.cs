using Hesabdari_Core.DTO;

namespace ServiceContracts
{
    public interface ILessonsAdderService
    {
        Task<ItemResult<LessonResult>> AddLesson(LessonRequest lessonAddRequest);
    }
}
