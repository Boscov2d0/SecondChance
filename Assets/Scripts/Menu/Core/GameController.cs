using SecondChanse.Data;
using SecondChanse.Menu.Data;
using SecondChanse.Menu.Tools;
using SecondChanse.Tools;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SecondChanse.Menu.Core
{
    public class GameController : ObjectsDisposer
    {
        private readonly SaveLoadManager _saveLoadManager;
        private readonly VideoManager _videoManager;
        private readonly AudioManager _audioManager;
        private readonly GameManager _gameManager;

        public GameController(SaveLoadManager saveLoadManager, VideoManager videoManager, 
                              AudioManager audioManager, GameManager gameManager)
        {
            _saveLoadManager = saveLoadManager;
            _videoManager = videoManager;
            _audioManager = audioManager;
            _gameManager = gameManager;

            _gameManager.State.SubscribeOnChange(OnStateChange);

            SetSettings();
        }
        protected override void OnDispose()
        {
            _gameManager.State.UnSubscribeOnChange(OnStateChange);

            base.OnDispose();
        }
        private void OnStateChange()
        {
            switch (_gameManager.State.Value)
            {
                case MenuState.LoadStory:
                    LoadScene();
                    break;
                case MenuState.Exit:
                    Quit();
                    break;
            }
        }
        private void SetSettings()
        {
            SetVideoSettings();
            SetAudioSettings();
        }
        private void SetVideoSettings()
        {
            if (!_gameManager.OldSave)
            {
                _videoManager.ScreenResolutionsWidth = Screen.currentResolution.width;
                _videoManager.ScreenResolutionsHeight = Screen.currentResolution.height;
                _videoManager.ScreenResolutionsRefreshRate = Screen.currentResolution.refreshRate;
                _videoManager.Fullscreen = true;
                Screen.SetResolution(_videoManager.ScreenResolutionsWidth, _videoManager.ScreenResolutionsHeight, _videoManager.Fullscreen, _videoManager.ScreenResolutionsRefreshRate);
                Saver.SaveSettingsData(_saveLoadManager, _videoManager, _audioManager);
            }
            else
            {
                Screen.fullScreen = _videoManager.Fullscreen;
                Screen.SetResolution(_videoManager.ScreenResolutionsWidth, _videoManager.ScreenResolutionsHeight, _videoManager.Fullscreen, _videoManager.ScreenResolutionsRefreshRate);
            }
        }
        private void SetAudioSettings()
        {
            _audioManager.AudioMixer.SetFloat(Keys.AudioKeys.Sound.ToString(), Mathf.Log10(_audioManager.SoundsValue) * 20);
            if (_audioManager.SoundsValue == 0)
                _audioManager.AudioMixer.SetFloat(Keys.AudioKeys.Sound.ToString(), -80);
            _audioManager.AudioMixer.SetFloat(Keys.AudioKeys.Music.ToString(), Mathf.Log10(_audioManager.MusicValue) * 20);
            if (_audioManager.MusicValue == 0)
                _audioManager.AudioMixer.SetFloat(Keys.AudioKeys.Music.ToString(), -80);
        }
        private void LoadScene()=> SceneManager.LoadScene(Keys.SceneNameKeys.Game.ToString());
        private void Quit() => Application.Quit();
    }
}