using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace Hesabdari_UI.Controllers;

public class UserCoursesController  : BaseController
{
    private readonly IUserCoursesDeleterService _userCoursesDeleterService;
    private readonly IUserCoursesGetterService _userCoursesGetterService;
    private readonly IUserCoursesAdderService _userCoursesAdderService;

    public UserCoursesController(IUserCoursesDeleterService userCoursesDeleterService, IUserCoursesGetterService userCoursesGetterService, IUserCoursesAdderService userCoursesAdderService)
    {
        _userCoursesDeleterService = userCoursesDeleterService;
        _userCoursesGetterService = userCoursesGetterService;
        _userCoursesAdderService = userCoursesAdderService;
    }

    [HttpPost("{courseId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(int courseId)
    {
        await _userCoursesAdderService.AddUserCourse(courseId);

        return Ok();
    }
    
    [HttpDelete("{courseId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int courseId)
    {
        await _userCoursesDeleterService.DeleteUserCourse(courseId);
        return Ok();
    }
}