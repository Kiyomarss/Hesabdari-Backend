using ContactsManager.Core.DTO;
using Hesabdari_Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace Hesabdari_UI.Controllers;

public class HeroSlidesController  : BaseController
{
    private readonly IHeroSlidesDeleterService _heroSlidesDeleterService;
    private readonly IHeroSlidesGetterService _heroSlidesGetterService;
    private readonly IHeroSlidesAdderService _heroSlidesAdderService;
    private readonly IHeroSlidesUpdaterService _heroSlidesUpdaterService;

    public HeroSlidesController(IHeroSlidesDeleterService heroSlidesDeleterService, IHeroSlidesGetterService heroSlidesGetterService, IHeroSlidesAdderService heroSlidesAdderService, IHeroSlidesUpdaterService heroSlidesUpdaterService)
    {
        _heroSlidesDeleterService = heroSlidesDeleterService;
        _heroSlidesGetterService = heroSlidesGetterService;
        _heroSlidesAdderService = heroSlidesAdderService;
        _heroSlidesUpdaterService = heroSlidesUpdaterService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(HeroSlideUpsertRequest dto)
    {
        if (dto.Image is { Length: > 0 })
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var fileExtension = Path.GetExtension(dto.Image.FileName).ToLower();

            if (!allowedExtensions.Contains(fileExtension))
            {
                return BadRequest(new { Message = "Invalid file type. Only images are allowed." });
            }

            dto.ImageUrl = await SaveNewImageAsync(dto.Image);
        }

        var heroSlideResponse = await _heroSlidesAdderService.AddHeroSlide(dto);

        return Ok(new
        {
            Message = "HeroSlide created successfully",
            HeroSlide = heroSlideResponse
        });
    }

    [HttpPut]
    public async Task<IActionResult> Edit(HeroSlideUpsertRequest dto)
    {
        HeroSlideResponse? existingHeroSlide = await _heroSlidesGetterService.GetHeroSlideByHeroSlideId(dto.Id);
        if (existingHeroSlide == null)
        {
            return NotFound(new { Message = "HeroSlide not found" });
        }

        if (dto.Image is { Length: > 0 })
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var fileExtension = Path.GetExtension(dto.Image.FileName).ToLower();
            if (!allowedExtensions.Contains(fileExtension))
            {
                return BadRequest(new { Message = "Invalid file type. Only images are allowed." });
            }

            DeleteOldImage(existingHeroSlide.ImageUrl);

            dto.ImageUrl = await SaveNewImageAsync(dto.Image);
        }
        else
        {
            // اگر تصویر جدید آپلود نشده، تصویر قبلی حفظ شود
            dto.ImageUrl = existingHeroSlide.ImageUrl;
        }

        HeroSlideResponse updatedHeroSlide = await _heroSlidesUpdaterService.UpdateHeroSlide(dto);

        return Ok(new
        {
            Message = "HeroSlide updated successfully",
            HeroSlide = updatedHeroSlide
        });
    }

    private void DeleteOldImage(string? imagePath)
    {
        if (!string.IsNullOrEmpty(imagePath))
        {
            var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imagePath.TrimStart('/'));
            if (System.IO.File.Exists(oldFilePath))
            {
                System.IO.File.Delete(oldFilePath);
            }
        }
    }

    private async Task<string> SaveNewImageAsync(IFormFile image)
    {
        var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
        var imagesFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

        if (!Directory.Exists(imagesFolderPath))
        {
            Directory.CreateDirectory(imagesFolderPath);
        }

        var filePath = Path.Combine(imagesFolderPath, fileName);

        await using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await image.CopyToAsync(stream);
        }

        return $"/images/{fileName}";
    }
    
    [HttpGet]
    public async Task<IActionResult> GetHeroSlides()
    {
        var heroSlides = await _heroSlidesGetterService.GetHeroSlides();
        return Ok(new { HeroSlides = heroSlides });
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleteHeroSlide = await _heroSlidesDeleterService.DeleteHeroSlide(id);
        return Ok(new { isDeleted = deleteHeroSlide });
    }
}