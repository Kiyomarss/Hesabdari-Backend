using System.ComponentModel.DataAnnotations;

namespace Hesabdari_Core.Domain.Entities;

public class Testimonial
{
    [Key]
    public int Id { get; set; }
    
    public string PositionAndCompany { get; set; }
    
    public string Content  { get; set; }
    
    public string? ImageUrl { get; set; }
    
    public int Order { get; set; }
    
    public bool IsActive { get; set; }
}