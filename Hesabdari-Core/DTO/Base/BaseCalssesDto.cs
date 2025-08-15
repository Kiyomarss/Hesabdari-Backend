namespace Hesabdari_Core.DTO;

public record ItemsResult<T>(List<T> Data);

public record ItemResult<T>(T Data);

public record FileUpdateResult(int Id, string ImageUrl);

public record IdListDto<TId>(List<TId> IdList);

public record IdDto<TId>(TId Id);