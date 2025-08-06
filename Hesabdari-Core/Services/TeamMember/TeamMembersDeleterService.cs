using Hesabdari_Core.ServiceContracts.Storage;
using ServiceContracts;
using RepositoryContracts;

namespace Services
{
    public class TeamMembersDeleterService : ITeamMembersDeleterService
    {
        private readonly ITeamMembersRepository _teamMembersRepository;
        private readonly IImageStorageService _imageStorageService;

        //constructor
        public TeamMembersDeleterService(
            ITeamMembersRepository teamMembersRepository,
            IImageStorageService imageStorageService
        )
        {
            _teamMembersRepository = teamMembersRepository;
            _imageStorageService = imageStorageService;
        }

        public async Task DeleteTeamMember(int teamMemberId)
        {
            var teamMember = await _teamMembersRepository.FindTeamMemberById(teamMemberId);

            if (teamMember == null)
                throw new KeyNotFoundException($"teamMember with ID {teamMemberId} does not exist.");

            await _imageStorageService.DeleteOldImagesAsync(teamMember.ImageUrl);

            await _teamMembersRepository.DeleteTeamMember(teamMemberId);
        }
    }
}