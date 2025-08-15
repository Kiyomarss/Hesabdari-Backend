using Hesabdari_Core.DTO;

namespace ServiceContracts
{
    public interface ITeamMembersGetterService
    {
        Task<ItemsResult<TeamMemberResult>> GetTeamMembers();

        Task<ItemsResult<TeamMemberDashboardResult>> GetDashboardTeamMembers();
    }
}