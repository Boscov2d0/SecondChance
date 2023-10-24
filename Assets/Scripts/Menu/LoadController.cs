using SecondChanse.Data;
using SecondChanse.Menu.Data;
using SecondChanse.Menu.Tools;
using SecondChanse.Tools;

namespace SecondChanse.Core
{

    public class LoadController : ObjectsDisposer
    {
        private readonly SaveLoadManager _saveLoadManager;
        private readonly LocalizationManager _localizationManager;
        private readonly VideoManager _videoManager;
        private readonly AudioManager _audioManager;

        public LoadController(SaveLoadManager saveLoadManager, LocalizationManager localizationManager, 
                              VideoManager videoManager, AudioManager audioManager)
        {
            _saveLoadManager = saveLoadManager;
            _localizationManager = localizationManager;
            _videoManager = videoManager;
            _audioManager = audioManager;

            LoadSettingsData();
        }

        private void LoadSettingsData()
        {
            _saveLoadManager.SettingsData = JSONDataLoadSaver<SettingsData>.Load(_saveLoadManager.SettingsDataPath);

            _localizationManager.Language.Value = _saveLoadManager.SettingsData.Language;
            _videoManager.ScreenResolutionsWidth = _saveLoadManager.SettingsData.WidthScreen;
            _videoManager.ScreenResolutionsHeight = _saveLoadManager.SettingsData.HeightScreen;
            _videoManager.ScreenResolutionsRefreshRate = _saveLoadManager.SettingsData.RefreshRate;
            _videoManager.Fullscreen = _saveLoadManager.SettingsData.Fullscreen;
            _audioManager.SoundsValue = _saveLoadManager.SettingsData.SoundsVolume;
            _audioManager.MusicValue = _saveLoadManager.SettingsData.MusicVolume;
        }
    }
}