using SecondChanse.Data;
using SecondChanse.Menu.Data;

namespace SecondChanse.Menu.Tools
{
    public static class Saver
    {
        public static void SaveSettingsData(SaveLoadManager saveLoadManager, VideoManager videoManager, AudioManager audioManager)
        {
            saveLoadManager.SettingsData.OldSave = true;
            saveLoadManager.SettingsData.WidthScreen = videoManager.ScreenResolutionsWidth;
            saveLoadManager.SettingsData.HeightScreen = videoManager.ScreenResolutionsHeight;
            saveLoadManager.SettingsData.RefreshRate = videoManager.ScreenResolutionsRefreshRate;
            saveLoadManager.SettingsData.Fullscreen = videoManager.Fullscreen;
            saveLoadManager.SettingsData.SoundsVolume = audioManager.SoundsValue;
            saveLoadManager.SettingsData.MusicVolume = audioManager.MusicValue;

            JSONDataLoadSaver<SettingsData>.SaveData(saveLoadManager.SettingsData, saveLoadManager.SettingsDataPath);
        }
        public static void SaveSettingsData(SaveLoadManager saveLoadManager, LocalizationManager localizationManager, VideoManager videoManager, AudioManager audioManager)
        {
            saveLoadManager.SettingsData.OldSave = true;
            saveLoadManager.SettingsData.Language = localizationManager.Language.Value;
            saveLoadManager.SettingsData.WidthScreen = videoManager.ScreenResolutionsWidth;
            saveLoadManager.SettingsData.HeightScreen = videoManager.ScreenResolutionsHeight;
            saveLoadManager.SettingsData.RefreshRate = videoManager.ScreenResolutionsRefreshRate;
            saveLoadManager.SettingsData.Fullscreen = videoManager.Fullscreen;
            saveLoadManager.SettingsData.SoundsVolume = audioManager.SoundsValue;
            saveLoadManager.SettingsData.MusicVolume = audioManager.MusicValue;

            JSONDataLoadSaver<SettingsData>.SaveData(saveLoadManager.SettingsData, saveLoadManager.SettingsDataPath);
        }
    }
}