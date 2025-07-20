using Hesabdari_Core.Domain.Entities;
using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.Setting;
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
    public async Task<IActionResult> EditSettingsSlides(SettingsSlidesDto dto)
    {
        var result = await _settingUpdaterService.UpdateSettingsSlides(dto);
        
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateLogo(LogoRequest dto)
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