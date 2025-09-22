namespace ServiceContracts
{
    public interface ILessonsDeleterService
    {
        Task DeleteLesson(int lessonId);
    }    
}
