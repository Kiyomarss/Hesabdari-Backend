using Microsoft.AspNetCore.Http;

namespace Hesabdari_Core.DTO;

public class TestimonialRequest
{
    public int? Id { get; set; }
    
    public string PositionAndCompany { get; set; }
    
    public string Content { get; set; }
    
    public int Order { get; set; }
    
    public bool IsActive { get; set; }
}