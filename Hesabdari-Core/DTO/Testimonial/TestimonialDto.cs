namespace Hesabdari_Core.DTO;

public record TestimonialResult(int Id, string PositionAndCompany, string Content, string? ImageUrl, int Order, bool IsActive);

public record TestimonialDashboardResult(int Id, string PositionAndCompany, string Content, string? ImageUrl, int Order);
