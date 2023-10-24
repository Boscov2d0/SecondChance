using SecondChanse.Core;
using SecondChanse.Data;
using SecondChanse.Menu.Data;
using SecondChanse.Menu.UI.Controller;
using SecondChanse.Tools;
using UnityEngine;

namespace SecondChanse.Menu.Core
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private SaveLoadManager _saveLoadManager;
        [SerializeField] private LocalizationManager _localizationManager;
        [SerializeField] private VideoManager _videoManager;
        [SerializeField] private AudioManager _audioManager;
        [SerializeField] private PlayerProfile _playerProfile;
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private UIManager _uiManager;

        private LoadController _loadController;
        private LocalizationController _localizationController;
        private MainUIController _mainUIController;
        private GameController _gameController;

        private void Awake()
        {
            _playerProfile.Story = Story.Menu;

            ResourcesLoader.InstantiateObject<Camera>(_gameManager.CameraPath);
            ResourcesLoader.InstantiateObject<AudioController>(_gameManager.AudioControlerPath);


            _loadController = new LoadController(_saveLoadManager, _localizationManager, 
                                                 _videoManager, _audioManager);
            _localizationController = new LocalizationController(_saveLoadManager, _localizationManager);
            _mainUIController = new MainUIController(_saveLoadManager, _localizationManager, 
                                                     _videoManager, _audioManager, 
                                                     _playerProfile, _gameManager, _uiManager);
            _gameController = new GameController(_saveLoadManager, _videoManager, _audioManager, _gameManager);
        }
        private void OnDestroy()
        {
            _loadController?.Dispose();
            _localizationController?.Dispose();
            _mainUIController?.Dispose();
            _gameController?.Dispose();
        }
    }
}