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
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromForm] HeroSlideUpsertRequest dto)
    {
        var heroSlides = await _heroSlidesAdderService.AddHeroSlide(dto);

        return Ok(new
        {
            HeroSlides = heroSlides,
            Message = "HeroSlide created successfully"
        });
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit([FromForm] HeroSlideUpsertRequest dto)
    {
        var heroSlides = await _heroSlidesUpdaterService.UpdateHeroSlide(dto);

        return Ok(new
        {
            HeroSlides = heroSlides,
            Message = "HeroSlide updated successfully"
        });
    }
    
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleteHeroSlide = await _heroSlidesDeleterService.DeleteHeroSlide(id);
        return Ok(new { isDeleted = deleteHeroSlide });
    }
    
    #region Get

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetHeroSlideById(int id)
    {
        var heroSlide = await _heroSlidesGetterService.GetHeroSlideById(id);
        
        return Ok(new { HeroSlides = heroSlide });
    }
    
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetHeroSlides()
    {
        var heroSlides = await _heroSlidesGetterService.GetHeroSlides();
        return Ok(new { HeroSlides = heroSlides });
    }
    
    [HttpGet]
    public async Task<IActionResult> GetHeroSlidesImage()
    {
        var imageUrls = await _heroSlidesGetterService.GetHeroSlidesImageUrl();

        return Ok(imageUrls);
    }

    #endregion
}