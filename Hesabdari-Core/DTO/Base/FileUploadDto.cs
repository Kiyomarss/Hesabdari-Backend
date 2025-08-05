using Microsoft.AspNetCore.Http;

namespace Hesabdari_Core.DTO.Base;

public class FileUploadDto
{
    public int Id { get; set; }

    public required IFormFile File { get; set; }
}