using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.Base;

namespace ServiceContracts
{
    public interface ITeamMembersUpdaterService
    {
        Task<ItemResult<TeamMemberResult>> UpdateTeamMember(TeamMemberRequest teamMemberUpdateRequest);

        Task RemoveImageTeamMember(int teamMemberId);

        Task<ItemResult<FileUpdateResult>> UpdateImageTeamMember(FileUploadDto dto);
    }
}