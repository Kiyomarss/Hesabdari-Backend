namespace ServiceContracts
{
    public interface ITeamMembersDeleterService
    {
        Task DeleteTeamMember(int teamMemberId);
    }    
}
