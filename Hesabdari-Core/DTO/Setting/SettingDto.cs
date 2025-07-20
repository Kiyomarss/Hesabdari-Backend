using Microsoft.AspNetCore.Http;

namespace Hesabdari_Core.DTO.Setting;

public record SettingsSlidesResult(bool IsSlideAutoChangeEnabled, int? SlideIntervalInSeconds);
public record LogoResult(string? LogoUrl);

public record SettingUpdateRequest(bool IsSlideAutoChangeEnabled, int? SlideIntervalInSeconds, IFormFile? Image);

public class LogoRequest
{
    public IFormFile? Image { get; set; }
}

public class SettingsSlidesRequest
{
    public bool IsSlideAutoChangeEnabled { get; set; }
    
    public int SlideIntervalInSeconds { get; set; }
}

