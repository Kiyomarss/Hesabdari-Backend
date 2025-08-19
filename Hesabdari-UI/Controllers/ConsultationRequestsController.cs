using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.ConsultationRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace Hesabdari_UI.Controllers;

public class ConsultationRequestsController  : BaseController
{
    private readonly IConsultationRequestsDeleterService _consultationRequestsDeleterService;
    private readonly IConsultationRequestsGetterService _consultationRequestsGetterService;
    private readonly IConsultationRequestsAdderService _consultationRequestsAdderService;
    private readonly IConsultationRequestsUpdaterService _consultationRequestsUpdaterService;

    public ConsultationRequestsController(IConsultationRequestsDeleterService consultationRequestsDeleterService, IConsultationRequestsGetterService consultationRequestsGetterService, IConsultationRequestsAdderService consultationRequestsAdderService, IConsultationRequestsUpdaterService consultationRequestsUpdaterService)
    {
        _consultationRequestsDeleterService = consultationRequestsDeleterService;
        _consultationRequestsGetterService = consultationRequestsGetterService;
        _consultationRequestsAdderService = consultationRequestsAdderService;
        _consultationRequestsUpdaterService = consultationRequestsUpdaterService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateConsultationRequestDto dto)
    {
        await _consultationRequestsAdderService.AddConsultationRequest(dto);

        return Ok();
    }
    
    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(List<long> idList)
    {
        await _consultationRequestsDeleterService.DeleteConsultationRequests(idList);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(long id)
    {
        await _consultationRequestsDeleterService.DeleteConsultationRequests([id]);
        return Ok();
    }
    
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> SetStarredStatus(long id)
    {
        await _consultationRequestsUpdaterService.SetStarredStatus(id);
        return Ok();
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetConsultationRequests([FromQuery] PaginationRequestDto dto)
    {
        var result = await _consultationRequestsGetterService.GetConsultationRequests(dto);
        return Ok(result);
    }
    
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetStarredConsultationRequests()
    {
        var result = await _consultationRequestsGetterService.GetStarredConsultationRequests();
        return Ok(result);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetUnreadCount()
    {
        var count = await _consultationRequestsGetterService.GetUnreadCount();

        return Ok(count);
    }
}