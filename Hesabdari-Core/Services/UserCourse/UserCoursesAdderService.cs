using Hesabdari_Core.Domain.Entities;
using Hesabdari_Core.DTO;
using Hesabdari_Core.ServiceContracts;
using Hesabdari_Core.ServiceContracts.Storage;
using ServiceContracts;
using RepositoryContracts;

namespace Services
{
    public class UserCoursesAdderService : IUserCoursesAdderService
    {
        private readonly IUserCoursesRepository _userCoursesRepository;
        private readonly IIdentityService _identityService;

        public UserCoursesAdderService(
            IUserCoursesRepository userCoursesRepository,
            IIdentityService identityService
        )
        {
            _userCoursesRepository = userCoursesRepository;
            _identityService = identityService;
        }

        public async Task AddUserCourse(int courseId)
        {
            var currentUser = await _identityService.GetCurrentUserAsync();

            var userCourse = new UserCourse
            {
                UserId = currentUser.Id,
                CourseId = courseId
            };

            await _userCoursesRepository.AddUserCourse(userCourse);
        }
    }
}