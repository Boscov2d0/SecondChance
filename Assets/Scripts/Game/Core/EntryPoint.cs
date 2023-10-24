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
        private GameController _gameController;

        private void Awake()
        {
            SetStory();

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
            _gameController?.Dispose();
        }
        private void SetStory()
        {
            switch (_playerProfile.Story)
            {
                case Story.CherryBlossomFestival:
                    _gameManager = _managers.CherryBlossomFestivalGameManager;
                    _cardsSpriteManager = _managers.CherryBlossomFestivalCardsSpriteManager;
                    _localizationManager.CurrentCardsText = _localizationManager.CherryBlossomFestivalText;
                    break;
                case Story.BloodInTheGutter:
                    _gameManager = _managers.BloodInTheGutterGameManager;
                    _cardsSpriteManager = _managers.BloodInTheGutterCardsSpriteManager;
                    _localizationManager.CurrentCardsText = _localizationManager.BloodInTheGutterText;
                    break;
            }
        }
    }
}