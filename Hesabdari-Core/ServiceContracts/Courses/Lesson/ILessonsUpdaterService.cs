using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.Base;

namespace ServiceContracts
{
    public interface ILessonsUpdaterService
    {
        Task<ItemResult<LessonResult>> UpdateLesson(LessonRequest lessonUpdateRequest);

        Task RemoveVideoLesson(int lessonId);

        Task<ItemResult<FileUpdateResult>> UpdateVideoLesson(FileUploadDto dto);
    }
}