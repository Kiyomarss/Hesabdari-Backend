namespace Hesabdari_Core.DTO;

public record GetImageUrlResult(string Status);

public record ImagesResponse (List<string> Images);

public record GetHeroSlidesResult(int Id,string Title, string ImageUrl, int Order, bool IsActive, string StartDate, string EndDate);

public record GetHeroSlidesByIdResult(int Id,string Title, string ImageUrl, int Order, bool IsActive, string StartDate, string EndDate);
