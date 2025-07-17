using Hesabdari_Core.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Hesabdari_Core.DTO;

public class HeroSlideUpsertRequest
{
    public int Id { get; set; } = 0;
    
    public string Title { get; set; }
    
    public string? Link { get; set; }
    
    public int Order { get; set; }
    
    public bool IsActive { get; set; }
    
    public string? StartDate { get; set; }
        
    public string? EndDate { get; set; }
    
    public IFormFile?  Image { get; set; }
    
    public string? ImageUrl { get; set; }
    
    public string? RowVersion { get; set; }
}