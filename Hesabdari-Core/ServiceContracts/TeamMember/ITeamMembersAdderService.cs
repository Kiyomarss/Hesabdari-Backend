using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.Base;

namespace ServiceContracts
{
    public interface ITeamMembersAdderService
    {
        Task<ItemResult<TeamMemberResult>> AddTeamMember(TeamMemberRequest teamMemberAddRequest);
    }
}
