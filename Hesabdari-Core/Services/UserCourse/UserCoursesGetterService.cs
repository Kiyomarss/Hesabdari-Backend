using ServiceContracts;
using Hesabdari_Core.DTO;
using Hesabdari_Core.ServiceContracts;
using RepositoryContracts;

namespace Services
{
    public class UserCoursesGetterService : IUserCoursesGetterService
    {
        private readonly IUserCoursesRepository _userCoursesRepository;
        private readonly IIdentityService _identityService;

        public UserCoursesGetterService(
            IUserCoursesRepository userCoursesRepository,
            IIdentityService identityService)
        {
            _userCoursesRepository = userCoursesRepository;
            _identityService = identityService;
        }
        
        public virtual async Task<List<CourseSummaryDto>> FindCourseIdsByUserId()
        {
            var currentUser = await _identityService.GetCurrentUserAsync();
            
            return await _userCoursesRepository.FindCourseIdsByUserId(currentUser.Id);
        }
}
}