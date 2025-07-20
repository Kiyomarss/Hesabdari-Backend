using Microsoft.AspNetCore.Http;

namespace Hesabdari_Core.DTO.Setting;

public record SettingsSlidesDto(bool IsSlideAutoChangeEnabled, int? SlideIntervalInSeconds);
public record LogoResult(string? LogoUrl);

public record SettingUpdateRequest(bool IsSlideAutoChangeEnabled, int? SlideIntervalInSeconds, IFormFile? Image);
public record LogoRequest(IFormFile Image);
