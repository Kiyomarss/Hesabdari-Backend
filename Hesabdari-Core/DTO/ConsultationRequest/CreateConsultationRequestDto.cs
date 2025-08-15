namespace Hesabdari_Core.DTO.ConsultationRequest;

public record CreateConsultationRequestDto(
    string FullName,
    string? CompanyName,
    string? Email,
    string PhoneNumber,
    string Description,
    string ServiceType
);