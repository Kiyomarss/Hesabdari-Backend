using ContactsManager.Core.DTO;
using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace Hesabdari_UI.Controllers;

public class TestimonialsController  : BaseController
{
    private readonly ITestimonialsDeleterService _testimonialsDeleterService;
    private readonly ITestimonialsGetterService _testimonialsGetterService;
    private readonly ITestimonialsAdderService _testimonialsAdderService;
    private readonly ITestimonialsUpdaterService _testimonialsesUpdaterService;

    public TestimonialsController(ITestimonialsDeleterService testimonialsDeleterService, ITestimonialsGetterService testimonialsGetterService, ITestimonialsAdderService testimonialsAdderService, ITestimonialsUpdaterService testimonialsesUpdaterService)
    {
        _testimonialsDeleterService = testimonialsDeleterService;
        _testimonialsGetterService = testimonialsGetterService;
        _testimonialsAdderService = testimonialsAdderService;
        _testimonialsesUpdaterService = testimonialsesUpdaterService;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(TestimonialRequest dto)
    {
        var testimonials = await _testimonialsAdderService.AddTestimonial(dto);

        return Ok(testimonials);
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(TestimonialRequest dto)
    {
        var testimonials = await _testimonialsesUpdaterService.UpdateTestimonial(dto);

        return Ok(testimonials);
    }
    
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _testimonialsDeleterService.DeleteTestimonial(id);
        return Ok();
    }
    
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> RemoveImageTestimonial(int id)
    {
        await _testimonialsesUpdaterService.RemoveImageTestimonial(id);
        return Ok();
    }
    
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateImageTestimonial([FromForm] FileUploadDto dto)
    {
        await _testimonialsesUpdaterService.UpdateImageTestimonial(dto);

        return Ok();
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetTestimonials()
    {
        var testimonials = await _testimonialsGetterService.GetTestimonials();
        return Ok(testimonials);
    }

    [HttpGet]
    public async Task<IActionResult> GetDashboardTestimonials()
    {
        var testimonials = await _testimonialsGetterService.GetDashboardTestimonials();

        return Ok(testimonials);
    }
}