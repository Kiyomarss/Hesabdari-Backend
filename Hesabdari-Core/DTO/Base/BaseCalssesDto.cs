namespace Hesabdari_Core.DTO;

public record ItemsResult<T>(List<T> Data);

public record ItemResult<T>(T Data);

public record FileUpdateResult(int Id, string ImageUrl);
