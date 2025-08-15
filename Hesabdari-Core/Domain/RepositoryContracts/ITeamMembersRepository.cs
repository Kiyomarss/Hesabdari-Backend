using Hesabdari_Core.Domain.Entities;
using Hesabdari_Core.DTO;

namespace RepositoryContracts;

public interface ITeamMembersRepository
{
    Task<TeamMember> AddTeamMember(TeamMember teamMember);

    Task UpdateTeamMember();

    Task<List<TeamMember>> GetTeamMembers();

    Task<List<TeamMember>> GetDashboardTeamMembers();
    
    Task<TeamMember?> FindTeamMemberById(int teamMemberId);

    Task<bool> DeleteTeamMember(int teamMemberId);
    
    Task<bool> DeleteImageTeamMember(int teamMemberId);
}