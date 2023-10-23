using SecondChanse.Data;
using SecondChanse.Menu.Data;
using SecondChanse.Menu.Tools;
using SecondChanse.Menu.UI.View;
using SecondChanse.Tools;
using UnityEngine;
using UnityEngine.UI;

namespace SecondChanse.Menu.UI.Controller
{
    public class SettingsUIController : ObjectsDisposer
    {
        private readonly SaveLoadManager _saveLoadManager;
        private readonly LocalizationManager _localizationManager;
        private readonly VideoManager _videoManager;
        private readonly AudioManager _audioManager;
        private readonly GameManager _gameManager;
        private readonly SettingsCanvasView _settingsCanvas;

        private int _width;
        private int _height;
        private int _refreshRate;

        public SettingsUIController(SaveLoadManager saveLoadManager, LocalizationManager localizationManager, 
                                    VideoManager videoManager, AudioManager audioManager, 
                                    GameManager gameManager, UIManager uiManager)
        {
            _saveLoadManager = saveLoadManager;
            _localizationManager = localizationManager;
            _videoManager = videoManager;
            _audioManager = audioManager;
            _gameManager = gameManager;

            _settingsCanvas = ResourcesLoader.InstantiateAndGetObject<SettingsCanvasView>(uiManager.UIObjectsPath + uiManager.SetingsCanvasPath);
            AddGameObject(_settingsCanvas.gameObject);
            _settingsCanvas.Initialize(RussianLanguage, EnglishLanguage, ChineeseLanguage,
                                      SetScreenresolution, FullScreenOn, FullScreenOff,
                                      OnSoundValuseChange, OnMusicValuseChange,
                                      Back);
        }

        private void RussianLanguage() 
        {
            SimpleButtonSound();
            _localizationManager.Language.Value = Keys.LanguageKeys.ru_RU.ToString();
        }
        private void EnglishLanguage()
        {
            SimpleButtonSound();
            _localizationManager.Language.Value = Keys.LanguageKeys.en_US.ToString();
        }
        private void ChineeseLanguage()
        {
            SimpleButtonSound();
            _localizationManager.Language.Value = Keys.LanguageKeys.zh_ZH.ToString();
        }
        private void SetScreenresolution(int index)
        {
            SimpleButtonSound();
            ParseDropdown(_settingsCanvas.ScreenResolutionDropdown);
            Screen.SetResolution(_width, _height, _videoManager.Fullscreen, _refreshRate);
            _videoManager.ScreenResolutionsWidth = _width;
            _videoManager.ScreenResolutionsHeight = _height;
            _videoManager.ScreenResolutionsRefreshRate = _refreshRate;
        }
        private void ParseDropdown(Dropdown screenResolutionDropdown)
        {
            char[] delimiterChars = { 'x', '@', 'H' };
            string[] resolutions = screenResolutionDropdown.options[screenResolutionDropdown.value].text.Split(delimiterChars);

            _width = int.Parse(resolutions[0]);
            _height = int.Parse(resolutions[1]);
            _refreshRate = int.Parse(resolutions[2]);
        }
        private void FullScreenOn()
        {
            SimpleButtonSound();
            Screen.fullScreen = true;
            _videoManager.Fullscreen = true;
        }
        private void FullScreenOff()
        {
            SimpleButtonSound();
            Screen.fullScreen = false;
            _videoManager.Fullscreen = false;
        }
        private void OnSoundValuseChange(float value)
        {
            SimpleButtonSound();
            _audioManager.SoundsValue = value;
            _audioManager.AudioMixer.SetFloat(Keys.AudioKeys.Sound.ToString(), Mathf.Log10(_audioManager.SoundsValue) * 20);
            if (value == 0)
                _audioManager.AudioMixer.SetFloat(Keys.AudioKeys.Sound.ToString(), -80);
        }
        private void OnMusicValuseChange(float value)
        {
            SimpleButtonSound();
            _audioManager.MusicValue = value;
            _audioManager.AudioMixer.SetFloat(Keys.AudioKeys.Music.ToString(), Mathf.Log10(_audioManager.MusicValue) * 20);
            if (value == 0)
                _audioManager.AudioMixer.SetFloat(Keys.AudioKeys.Music.ToString(), -80);
        }
        private void Back() 
        {
            Saver.SaveSettingsData(_saveLoadManager, _localizationManager, _videoManager, _audioManager);
            ApplyButtonSound();
            _gameManager.State.Value = MenuState.Menu;
        }
        private void SimpleButtonSound() => _audioManager.SimpleClickAudioSource.Play();
        private void ApplyButtonSound() => _audioManager.ApplyClickAudioSource.Play();
    }
}