using Hesabdari_Core.DTO;

namespace ServiceContracts
{
    public interface ITeamMembersAdderService
    {
        Task<ItemResult<TeamMemberResult>> AddTeamMember(TeamMemberRequest teamMemberAddRequest);
    }
}
