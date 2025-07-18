using System.ComponentModel.DataAnnotations;

namespace Hesabdari_Core.Domain.Entities;

public class Setting
{
    [Key]
    public int Id { get; set; }
    
    public bool IsSlideAutoChangeEnabled { get; set; }
    
    public int? SlideIntervalInSeconds { get; set; }
    
    public string? LogoImageUrl { get; set; }
}