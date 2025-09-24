using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace Hesabdari_UI.Controllers;

public class ChaptersController : BaseController
{
    private readonly IChaptersDeleterService _chaptersDeleterService;
    private readonly IChaptersGetterService _chaptersGetterService;
    private readonly IChaptersAdderService _chaptersAdderService;
    private readonly IChaptersUpdaterService _chaptersesUpdaterService;

    public ChaptersController(IChaptersDeleterService chaptersDeleterService, IChaptersGetterService chaptersGetterService, IChaptersAdderService chaptersAdderService, IChaptersUpdaterService chaptersesUpdaterService)
    {
        _chaptersDeleterService = chaptersDeleterService;
        _chaptersGetterService = chaptersGetterService;
        _chaptersAdderService = chaptersAdderService;
        _chaptersesUpdaterService = chaptersesUpdaterService;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(ChapterRequest dto)
    {
        var chapters = await _chaptersAdderService.AddChapter(dto);

        return Ok(chapters);
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(ChapterRequest dto)
    {
        var chapters = await _chaptersesUpdaterService.UpdateChapter(dto);

        return Ok(chapters);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _chaptersDeleterService.DeleteChapter(id);

        return Ok();
    }
}