namespace ServiceContracts
{
    public interface IUserCoursesDeleterService
    {
        Task DeleteUserCourse(int courseId);
    }    
}
