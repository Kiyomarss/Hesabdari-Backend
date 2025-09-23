namespace ServiceContracts
{
    public interface ICoursesDeleterService
    {
        Task DeleteCourse(int courseId);
    }    
}
