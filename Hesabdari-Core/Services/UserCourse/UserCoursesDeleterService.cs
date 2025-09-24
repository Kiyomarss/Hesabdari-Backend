using Hesabdari_Core.ServiceContracts;
using Hesabdari_Core.ServiceContracts.Storage;
using ServiceContracts;
using RepositoryContracts;

namespace Services
{
    public class UserCoursesDeleterService : IUserCoursesDeleterService
    {
        private readonly IUserCoursesRepository _userCoursesRepository;
        private readonly IIdentityService _identityService;

        public UserCoursesDeleterService(
            IUserCoursesRepository userCoursesRepository,
            IIdentityService identityService
        )
        {
            _userCoursesRepository = userCoursesRepository;
            _identityService = identityService;
        }

        public async Task DeleteUserCourse(int courseId)
        {
            var currentUser = await _identityService.GetCurrentUserAsync();
            
            var userCourse = await _userCoursesRepository.FindUserCourse(courseId, currentUser.Id);

            if (userCourse == null)
                throw new KeyNotFoundException($"userCourse with ID {courseId} does not exist.");

            await _userCoursesRepository.DeleteUserCourseAsync(userCourse.Id);
        }
    }
}