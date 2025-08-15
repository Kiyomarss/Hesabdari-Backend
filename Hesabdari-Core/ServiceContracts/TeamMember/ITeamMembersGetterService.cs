using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.Base;

namespace ServiceContracts
{
    public interface ITeamMembersGetterService
    {
        Task<ItemsResult<TeamMemberResult>> GetTeamMembers();

        Task<ItemsResult<TeamMemberDashboardResult>> GetDashboardTeamMembers();
    }
}