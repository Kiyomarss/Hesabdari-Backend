using ServiceContracts;
using Hesabdari_Core.DTO;
using RepositoryContracts;

namespace Services
{
    public class TeamMembersGetterService : ITeamMembersGetterService
    {
        private readonly ITeamMembersRepository _teamMembersRepository;

        public TeamMembersGetterService(ITeamMembersRepository teamMembersRepository)
        {
            _teamMembersRepository = teamMembersRepository;
        }

        public virtual async Task<ItemsResult<TeamMemberResult>> GetTeamMembers()
        {
            var teamMembers = await _teamMembersRepository.GetTeamMembers();

            return new ItemsResult<TeamMemberResult>(
                                                      teamMembers.Select(x =>
                                                                              new TeamMemberResult(x.Id, x.FullName, x.Position, x.Bio, x.ImageUrl, x.Order, x.IsActive)
                                                                         ).ToList()
                                                     );
        }

        public virtual async Task<ItemsResult<TeamMemberDashboardResult>> GetDashboardTeamMembers()
        {
            var teamMembers = await _teamMembersRepository.GetDashboardTeamMembers();

            return new ItemsResult<TeamMemberDashboardResult>(
                                                              teamMembers.Select(x =>
                                                                                     new TeamMemberDashboardResult(x.Id, x.FullName, x.Position, x.Bio, x.ImageUrl, x.Order)
                                                                                ).ToList()
                                                             );
        }
    }
}