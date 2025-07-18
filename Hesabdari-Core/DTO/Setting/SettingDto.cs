using Microsoft.AspNetCore.Http;

namespace Hesabdari_Core.DTO.Setting;

public record SettingResult(bool IsSlideAutoChangeEnabled, int? SlideIntervalInSeconds, string LogoImageUrl);

public record SettingUpdateRequest(bool IsSlideAutoChangeEnabled, int? SlideIntervalInSeconds, IFormFile? Image);
