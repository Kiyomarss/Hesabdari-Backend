using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace Hesabdari_UI.Controllers;

public class TeamMembersController  : BaseController
{
    private readonly ITeamMembersDeleterService _teamMembersDeleterService;
    private readonly ITeamMembersGetterService _teamMembersGetterService;
    private readonly ITeamMembersAdderService _teamMembersAdderService;
    private readonly ITeamMembersUpdaterService _teamMembersUpdaterService;

    public TeamMembersController(ITeamMembersDeleterService teamMembersDeleterService, ITeamMembersGetterService teamMembersGetterService, ITeamMembersAdderService teamMembersAdderService, ITeamMembersUpdaterService teamMembersUpdaterService)
    {
        _teamMembersDeleterService = teamMembersDeleterService;
        _teamMembersGetterService = teamMembersGetterService;
        _teamMembersAdderService = teamMembersAdderService;
        _teamMembersUpdaterService = teamMembersUpdaterService;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(TeamMemberRequest dto)
    {
        var teamMembers = await _teamMembersAdderService.AddTeamMember(dto);

        return Ok(teamMembers);
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(TeamMemberRequest dto)
    {
        var teamMembers = await _teamMembersUpdaterService.UpdateTeamMember(dto);

        return Ok(teamMembers);
    }
    
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _teamMembersDeleterService.DeleteTeamMember(id);
        return Ok();
    }
    
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> RemoveImageTeamMember(int id)
    {
        await _teamMembersUpdaterService.RemoveImageTeamMember(id);
        return Ok();
    }
    
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateImageTeamMember([FromForm] FileUploadDto dto)
    {
        var result = await _teamMembersUpdaterService.UpdateImageTeamMember(dto);

        return Ok(result);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetTeamMembers()
    {
        var teamMembers = await _teamMembersGetterService.GetTeamMembers();
        return Ok(teamMembers);
    }

    [HttpGet]
    public async Task<IActionResult> GetDashboardTeamMembers()
    {
        var teamMembers = await _teamMembersGetterService.GetDashboardTeamMembers();

        return Ok(teamMembers);
    }
}