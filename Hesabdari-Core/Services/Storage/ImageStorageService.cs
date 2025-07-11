using Hesabdari_Core.ServiceContracts.Storage;
using Microsoft.AspNetCore.Http;

namespace Hesabdari_Core.Services.Storage;

public class ImageStorageService : IImageStorageService
{
    private readonly string _imageFolder;

    public ImageStorageService()
    {
        _imageFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
    }

    public async Task<string> SaveImageAsync(IFormFile image)
    {
        if (image == null || image.Length == 0)
            throw new ArgumentException("تصویر معتبر نیست.");
        
        var allowedExtensions = new[] { ".webp",".jpg", ".jpeg", ".png", ".gif" };
        var fileExtension = Path.GetExtension(image.FileName);
        
        if (!allowedExtensions.Contains(fileExtension))
            throw new ArgumentException("فرمت تصویر معتبر نیست.");

        var fileName = $"{Guid.NewGuid()}{fileExtension}";
        var filePath = Path.Combine(_imageFolder, fileName);

        if (!Directory.Exists(_imageFolder))
            Directory.CreateDirectory(_imageFolder);

        await using var stream = new FileStream(filePath, FileMode.Create);
        await image.CopyToAsync(stream);

        return $"/images/{fileName}";
    }

    public Task DeleteOldImage(string? imagePath)
    {
        if (string.IsNullOrEmpty(imagePath))
            return Task.CompletedTask;

        var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imagePath.TrimStart('/'));
        if (File.Exists(oldFilePath))
        {
            File.Delete(oldFilePath);
        }

        return Task.CompletedTask;
    }
}
