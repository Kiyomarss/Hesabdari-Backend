using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace Hesabdari_UI.Controllers;

public class LessonController  : BaseController
{
    private readonly ILessonsDeleterService _lessonsDeleterService;
    private readonly ILessonsGetterService _lessonsGetterService;
    private readonly ILessonsAdderService _lessonsAdderService;
    private readonly ILessonsUpdaterService _lessonsesUpdaterService;

    public LessonController(ILessonsDeleterService lessonsDeleterService, ILessonsGetterService lessonsGetterService, ILessonsAdderService lessonsAdderService, ILessonsUpdaterService lessonsesUpdaterService)
    {
        _lessonsDeleterService = lessonsDeleterService;
        _lessonsGetterService = lessonsGetterService;
        _lessonsAdderService = lessonsAdderService;
        _lessonsesUpdaterService = lessonsesUpdaterService;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(LessonRequest dto)
    {
        var lessons = await _lessonsAdderService.AddLesson(dto);

        return Ok(lessons);
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(LessonRequest dto)
    {
        var lessons = await _lessonsesUpdaterService.UpdateLesson(dto);

        return Ok(lessons);
    }
    
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _lessonsDeleterService.DeleteLesson(id);
        return Ok();
    }
    
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> RemoveVideoLesson(int id)
    {
        await _lessonsesUpdaterService.RemoveVideoLesson(id);
        return Ok();
    }
    
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateVideoLesson([FromForm] FileUploadDto dto)
    {
        var result = await _lessonsesUpdaterService.UpdateVideoLesson(dto);

        return Ok(result);
    }
}