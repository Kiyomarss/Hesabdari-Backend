using System.ComponentModel.DataAnnotations;

namespace Hesabdari_Core.Domain.Entities;

public class HeroSlide
{
    [Key]
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string ImageDesktopJpgUrl { get; set; }
    
    public string ImageDesktopWebpUrl { get; set; }
    
    public string ImageMobileJpgUrl { get; set; }
    
    public string ImageMobileWebpUrl { get; set; }  
    
    public string? Link { get; set; }
    
    public int Order { get; set; }
    
    public bool IsActive { get; set; }
    
    public DateTime? StartDate { get; set; }
    
    public DateTime? EndDate { get; set; }
    
    public DateTime CreateAt { get; set; }
    
    [Timestamp]
    public byte[] RowVersion { get; set; }
}