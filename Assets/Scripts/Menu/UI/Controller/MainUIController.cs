using SecondChanse.Data;
using SecondChanse.Menu.Data;
using SecondChanse.Tools;
using UnityEngine;

namespace SecondChanse.Menu.UI.Controller
{
    public class MainUIController : ObjectsDisposer
    {
        private readonly SaveLoadManager _saveLoadManager;
        private readonly LocalizationManager _localizationManager;
        private readonly VideoManager _videoManager;
        private readonly AudioManager _audioManager;
        private readonly PlayerProfile _playerProfile;
        private readonly GameManager _gameManager;
        private readonly UIManager _uiManager;

        private MenuUIController _menuUIController;
        private StoryMapUIController _storyMapUIController;
        private SettingsUIController _settingsUIController;

        public MainUIController(SaveLoadManager saveLoadManager, LocalizationManager localizationManager, 
                                VideoManager videoManager, AudioManager audioManager, 
                                PlayerProfile playerProfile, GameManager gameManager, UIManager uiManager)
        {
            _saveLoadManager = saveLoadManager;
            _localizationManager = localizationManager;
            _videoManager = videoManager;
            _audioManager = audioManager;
            _playerProfile = playerProfile;
            _gameManager = gameManager;
            _uiManager = uiManager;

            _gameManager.State.SubscribeOnChange(OnStateChange);
            _gameManager.State.Value = Tools.MenuState.Menu;
        }
        protected override void OnDispose()
        {
            _gameManager.State.UnSubscribeOnChange(OnStateChange);

            base.OnDispose();
        }
        private void OnStateChange()
        {
            ControllersDisposer();

            switch (_gameManager.State.Value)
            {
                case Tools.MenuState.Menu:
                    _menuUIController = new MenuUIController(_audioManager, _gameManager, _uiManager);
                    AddController(_menuUIController);
                    break;
                case Tools.MenuState.StoryMap:
                    _storyMapUIController = new StoryMapUIController(_audioManager, _playerProfile, 
                                                                     _gameManager, _uiManager);
                    AddController(_storyMapUIController);
                    break;
                case Tools.MenuState.Settings:
                    _settingsUIController = new SettingsUIController(_saveLoadManager, _localizationManager, 
                                                                     _videoManager, _audioManager, 
                                                                     _gameManager, _uiManager);
                    AddController(_settingsUIController);
                    break;
                case Tools.MenuState.Exit:
                    Application.Quit();
                    break;
            }
        }
        private void ControllersDisposer()
        {
            _menuUIController?.Dispose();
            _storyMapUIController?.Dispose();
            _settingsUIController?.Dispose();
        }
    }
}