using Hesabdari_Core.Domain.Entities;
using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.Setting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace Hesabdari_UI.Controllers;

public class SettingsController  : BaseController
{
    private readonly ISettingGetterService _settingGetterService;
    private readonly ISettingUpdaterService _settingUpdaterService;

    public SettingsController(ISettingGetterService settingGetterService, ISettingUpdaterService settingUpdaterService)
    {
        _settingGetterService = settingGetterService;
        _settingUpdaterService = settingUpdaterService;
    }
    
    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> EditSettingsSlides(SettingsSlidesRequest dto)
    {
        var result = await _settingUpdaterService.UpdateSettingsSlides(dto);
        
        return Ok(result);
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateLogo([FromForm] LogoRequest dto)
    {
        var result = await _settingUpdaterService.UpdateLogo(dto);
        
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetSettingsSlides()
    {
        var settingsSlides = await _settingGetterService.GetSettingsSlides();

        return Ok(settingsSlides);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetLogo()
    {
        var logo = await _settingGetterService.GetLogo();

        return Ok(logo);
    }
}