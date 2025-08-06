using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.Base;
using Hesabdari_Core.ServiceContracts.Storage;
using ServiceContracts;
using RepositoryContracts;

namespace Services
{
    public class TeamMembersUpdaterService : ITeamMembersUpdaterService
    {
        private readonly ITeamMembersRepository _teamMembersRepository;
        private readonly IImageStorageService _imageStorageService;

        public TeamMembersUpdaterService(
            ITeamMembersRepository teamMemberRepository,
            IImageStorageService imageStorageService)
        {
            _teamMembersRepository = teamMemberRepository;
            _imageStorageService = imageStorageService;
        }

        public async Task<ItemResult<TeamMemberResult>> UpdateTeamMember(TeamMemberRequest teamMemberUpdateRequest)
        {
            if (teamMemberUpdateRequest == null)
                throw new InvalidOperationException("TeamMember with the given ID does not exist.");

            var teamMember = await _teamMembersRepository.FindTeamMemberById((int)teamMemberUpdateRequest.Id);

            if (teamMember == null)
                throw new InvalidOperationException("TeamMember with the given ID does not exist.");

            teamMember.FullName = teamMemberUpdateRequest.FullName;
            teamMember.Position = teamMemberUpdateRequest.Position;
            teamMember.Bio = teamMemberUpdateRequest.Bio;
            teamMember.Order = teamMemberUpdateRequest.Order;
            teamMember.IsActive = teamMemberUpdateRequest.IsActive;

            await _teamMembersRepository.UpdateTeamMember();

            return new ItemResult<TeamMemberResult>(new TeamMemberResult(teamMember.Id,teamMember.FullName, teamMember.Position, teamMember.Bio, teamMember.ImageUrl, teamMember.Order, teamMember.IsActive));
        }

        public async Task RemoveImageTeamMember(int teamMemberId)
        {
            var teamMember = await _teamMembersRepository.FindTeamMemberById(teamMemberId);

            if (teamMember == null)
                throw new KeyNotFoundException($"teamMember with ID {teamMemberId} does not exist.");

            await _imageStorageService.DeleteOldImagesAsync(teamMember.ImageUrl);

            teamMember.ImageUrl = null;

            await _teamMembersRepository.UpdateTeamMember();
        }
        
        public async Task<ItemResult<FileUpdateResult>> UpdateImageTeamMember(FileUploadDto dto)
        {
            var teamMember = await _teamMembersRepository.FindTeamMemberById(dto.Id);

            if (teamMember == null)
                throw new KeyNotFoundException($"teamMember with ID {dto.Id} does not exist.");

            await _imageStorageService.DeleteOldImagesAsync(teamMember.ImageUrl);

            teamMember.ImageUrl = await _imageStorageService.SaveImageAsync(dto.Image);

            await _teamMembersRepository.UpdateTeamMember();

            return new ItemResult<FileUpdateResult>(new FileUpdateResult(teamMember.Id, teamMember.ImageUrl));
        }
    }
}