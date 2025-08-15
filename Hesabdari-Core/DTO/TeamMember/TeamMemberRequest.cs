namespace Hesabdari_Core.DTO;

public class TeamMemberRequest
{
    public int? Id { get; set; }
    
    public required string FullName { get; set; }

    public required string Position { get; set; }
    
    public required string Bio { get; set; }
    
    public int Order { get; set; }
    
    public bool IsActive { get; set; }
}