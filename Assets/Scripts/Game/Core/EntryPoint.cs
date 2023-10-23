using SecondChanse.Core;
using SecondChanse.Data;
using SecondChanse.Game.Data;
using SecondChanse.Tools;
using UnityEngine;

namespace SecondChanse.Game.Core
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private LocalizationManager _localizationManager;
        [SerializeField] private PlayerProfile _playerProfile;
        [SerializeField] private AudioManager _audioManager;
        [SerializeField] private StorysManagers _managers;
        [SerializeField] private UIManager _uiManager;

        private GameManager _gameManager;
        private CardsSpriteManager _cardsSpriteManager;
        private LocalizationController _localizationController;
        private GameController _gameController;

        private void Awake()
        {
            _localizationController = new LocalizationController(_localizationManager);

            ResourcesLoader.InstantiateObject<Camera>(_gameManager.CameraPath);
            ResourcesLoader.InstantiateObject<AudioController>(_gameManager.AudioControlerPath);

            _gameController = new GameController(_audioManager, _gameManager, _uiManager, _cardsSpriteManager);
        }
        private void FixedUpdate()
        {
            _gameController?.FixedExecute();
        }
        private void OnDestroy()
        {
            _localizationController?.Dispose();
            _gameController?.Dispose();
        }
    }
}