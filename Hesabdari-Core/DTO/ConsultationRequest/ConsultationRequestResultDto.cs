namespace Hesabdari_Core.DTO.ConsultationRequest;

public record ConsultationRequestResultDto(
    long Id,
    string FullName,
    string? CompanyName,
    string? Email,
    string PhoneNumber,
    string Description,
    string ServiceType,
    bool IsRead,
    bool IsStarred,
    string CreateAt
);

public record PaginationRequestDto(
    string? Status,
    int Page = 1,
    int PageSize = 10
);