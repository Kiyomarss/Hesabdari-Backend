namespace Hesabdari_Core.DTO.Base;

public record ItemsResult<T>(List<T> Data);

public record ItemResult<T>(T Data);