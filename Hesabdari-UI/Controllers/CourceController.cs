using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace Hesabdari_UI.Controllers;

public class CoursesController  : BaseController
{
    private readonly ICoursesDeleterService _coursesDeleterService;
    private readonly ICoursesGetterService _coursesGetterService;
    private readonly ICoursesAdderService _coursesAdderService;
    private readonly ICoursesUpdaterService _coursesesUpdaterService;

    public CoursesController(ICoursesDeleterService coursesDeleterService, ICoursesGetterService coursesGetterService, ICoursesAdderService coursesAdderService, ICoursesUpdaterService coursesesUpdaterService)
    {
        _coursesDeleterService = coursesDeleterService;
        _coursesGetterService = coursesGetterService;
        _coursesAdderService = coursesAdderService;
        _coursesesUpdaterService = coursesesUpdaterService;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(CourseRequest dto)
    {
        var courses = await _coursesAdderService.AddCourse(dto);

        return Ok(courses);
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(CourseRequest dto)
    {
        var courses = await _coursesesUpdaterService.UpdateCourse(dto);

        return Ok(courses);
    }
    
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _coursesDeleterService.DeleteCourse(id);
        return Ok();
    }
    
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> RemoveImageCourse(int id)
    {
        await _coursesesUpdaterService.RemoveImageCourse(id);
        return Ok();
    }
    
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateImageCourse([FromForm] FileUploadDto dto)
    {
        var result = await _coursesesUpdaterService.UpdateImageCourse(dto);

        return Ok(result);
    }
    
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> RemoveVideoCourse(int id)
    {
        await _coursesesUpdaterService.RemoveVideoCourse(id);
        return Ok();
    }
    
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateVideoCourse([FromForm] FileUploadDto dto)
    {
        var result = await _coursesesUpdaterService.UpdateVideoCourse(dto);

        return Ok(result);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetCourses()
    {
        var courses = await _coursesGetterService.GetCourses();
        return Ok(courses);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCourseById(int id)
    {
        var courses = await _coursesGetterService.GetCourseById(id);

        return Ok(courses);
    }
}