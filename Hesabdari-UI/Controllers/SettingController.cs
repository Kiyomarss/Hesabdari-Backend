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
    public async Task<IActionResult> Edit(SettingUpdateRequest dto)
    {
        await _settingUpdaterService.UpdateSetting(dto);
        
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetSettings()
    {
        var setting = await _settingGetterService.GetSetting();

        return Ok(setting);
    }
}