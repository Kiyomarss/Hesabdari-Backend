using Hesabdari_Core.Domain.Entities;
using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.Base;
using Hesabdari_Core.ServiceContracts;
using Hesabdari_Core.ServiceContracts.Storage;
using Hesabdari_Core.Utils;
using ServiceContracts;
using RepositoryContracts;
using Microsoft.Extensions.Logging;

namespace Services
{
    public class TeamMembersAdderService : ITeamMembersAdderService
    {
        private readonly ITeamMembersRepository _teamMembersRepository;
        private readonly IImageStorageService _imageStorageService;

        public TeamMembersAdderService(
            ITeamMembersRepository teamMembersRepository,
            IImageStorageService imageStorageService
        )
        {
            _teamMembersRepository = teamMembersRepository;
            _imageStorageService = imageStorageService;
        }

        public async Task<ItemResult<TeamMemberResult>> AddTeamMember(TeamMemberRequest teamMemberAddRequest)
        {
            var teamMember = new TeamMember();

            teamMember.FullName = teamMemberAddRequest.FullName;
            teamMember.Position = teamMemberAddRequest.Position;
            teamMember.Order = teamMemberAddRequest.Order;
            teamMember.IsActive = teamMemberAddRequest.IsActive;

            await _teamMembersRepository.AddTeamMember(teamMember);

            return new ItemResult<TeamMemberResult>(new TeamMemberResult(teamMember.Id, teamMember.FullName, teamMember.Position, teamMember.Bio, teamMember.ImageUrl, teamMember.Order, teamMember.IsActive));
        }
    }
}