using Hesabdari_Core.Domain.Entities;
using Hesabdari_Core.DTO;

namespace RepositoryContracts;

public interface ILessonsRepository
{
    Task<Lesson> AddLesson(Lesson lesson);

    Task<Lesson?> FindLessonById(int lessonId);

    Task UpdateLesson();

    Task<bool> DeleteLesson(int lessonId);

}