using Hesabdari_Core.DTO.Setting;
using Hesabdari_Core.ServiceContracts;
using Hesabdari_Core.ServiceContracts.Storage;
using ServiceContracts;
using RepositoryContracts;
using Microsoft.Extensions.Logging;

namespace Services
{
    public class SettingUpdaterService : ISettingUpdaterService
    {
        private readonly ISettingRepository _settingRepository;
        private readonly IImageStorageService _imageStorageService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SettingGetterService> _logger;

        public SettingUpdaterService(
            ISettingRepository settingRepository,
            IImageStorageService imageStorageService,
            IUnitOfWork unitOfWork,
            ILogger<SettingGetterService> logger)
        {
            _settingRepository = settingRepository;
            _imageStorageService = imageStorageService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<SettingsSlidesDto> UpdateSettingsSlides(SettingsSlidesDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var setting = await _settingRepository.GetSetting();

            setting.IsSlideAutoChangeEnabled = dto.IsSlideAutoChangeEnabled;

            setting.SlideIntervalInSeconds = !setting.IsSlideAutoChangeEnabled ? null : dto.SlideIntervalInSeconds;

            await _settingRepository.UpdateSetting();

            return new SettingsSlidesDto(setting.IsSlideAutoChangeEnabled, setting.SlideIntervalInSeconds);
        }

        public async Task<LogoResult> UpdateLogo(LogoRequest result)
        {
            if (result == null)
                throw new ArgumentNullException(nameof(result));

            var setting = await _settingRepository.GetSetting();

            await _imageStorageService.DeleteOldImage(setting.LogoImageUrl);

            setting.LogoImageUrl = await _imageStorageService.SaveImageAsync(result.Image);

            await _settingRepository.UpdateSetting();

            return new LogoResult(setting.LogoImageUrl);
        }
    }
}