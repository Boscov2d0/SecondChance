using SecondChanse.Data;
using SecondChanse.Menu.Data;

namespace SecondChanse.Menu.Tools
{
    public static class Saver
    {
        public static void SaveAllSettings(SaveLoadManager saveLoadManager, LocalizationManager localizationManager, VideoManager videoManager, AudioManager audioManager) 
        {
            SaveLanguageSettingsData(saveLoadManager, localizationManager);
            SaveVideoSettingsData(saveLoadManager, videoManager);
            SaveAudioSettingsData(saveLoadManager, audioManager);
        }
        public static void SaveLanguageSettingsData(SaveLoadManager saveLoadManager, LocalizationManager localizationManager)
        {
            saveLoadManager.SettingsData.Language = localizationManager.Language.Value;

            JSONDataLoadSaver<SettingsData>.SaveData(saveLoadManager.SettingsData, saveLoadManager.SettingsDataPath);
        }
        public static void SaveVideoSettingsData(SaveLoadManager saveLoadManager, VideoManager videoManager)
        {
            saveLoadManager.SettingsData.WidthScreen = videoManager.ScreenResolutionsWidth;
            saveLoadManager.SettingsData.HeightScreen = videoManager.ScreenResolutionsHeight;
            saveLoadManager.SettingsData.RefreshRate = videoManager.ScreenResolutionsRefreshRate;
            saveLoadManager.SettingsData.Fullscreen = videoManager.Fullscreen;

            JSONDataLoadSaver<SettingsData>.SaveData(saveLoadManager.SettingsData, saveLoadManager.SettingsDataPath);
        }
        public static void SaveAudioSettingsData(SaveLoadManager saveLoadManager, AudioManager audioManager)
        {
            saveLoadManager.SettingsData.SoundsVolume = audioManager.SoundsValue;
            saveLoadManager.SettingsData.MusicVolume = audioManager.MusicValue;

            JSONDataLoadSaver<SettingsData>.SaveData(saveLoadManager.SettingsData, saveLoadManager.SettingsDataPath);
        }
    }
}