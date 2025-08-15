using System.ComponentModel.DataAnnotations;

namespace Hesabdari_Core.Domain.Entities;

public class ConsultationRequest
{
    [Key] public long Id { get; set; }

    public string FullName { get; set; }

    public string? CompanyName { get; set; }
    
    public string? Email { get; set; }

    public string PhoneNumber { get; set; }
    
    public string Description { get; set; }
    
    public string ServiceType { get; set; }
    
    public bool IsRead { get; set; }
    
    public bool IsStarred { get; set; }
    
    public DateTime CreateAt { get; set; }
}