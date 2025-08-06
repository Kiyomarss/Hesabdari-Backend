namespace Hesabdari_Core.DTO;

public record TeamMemberResult(int Id, string FullName, string Position, string Bio, string? ImageUrl, int Order, bool IsActive);

public record TeamMemberDashboardResult(int Id, string FullName, string Position, string Bio, string? ImageUrl, int Order);
