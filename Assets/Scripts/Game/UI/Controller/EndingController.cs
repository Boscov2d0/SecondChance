using SecondChanse.Data;
using SecondChanse.Game.Data;
using SecondChanse.Game.UI.View;
using SecondChanse.Tools;

using static SecondChanse.Game.Tools.States;

namespace SecondChanse.Game.UI.Controller
{
    public class EndingController : ObjectsDisposer
    {
        private readonly AudioManager _audioManager;
        private readonly GameManager _gameManager;
        private readonly UIManager _uiManager;
        private readonly CardsSpriteManager _cardsSpriteManager;

        public EndingController(AudioManager audioManager, GameManager gameManager, UIManager uiManager, CardsSpriteManager cardsSpriteManager) 
        {
            _audioManager = audioManager;
            _gameManager = gameManager;
            _uiManager = uiManager;
            _cardsSpriteManager = cardsSpriteManager;

            EndingCanvasView endingCanvas = ResourcesLoader.InstantiateAndGetObject<EndingCanvasView>(uiManager.UIObjectsPath + uiManager.EndinsCanvasPath);
            AddGameObject(endingCanvas.gameObject);
            endingCanvas.Initialize(gameManager, cardsSpriteManager, ReadFullStory, PlayAgain, Menu);
        }
        private void ReadFullStory() 
        {
            SimpleButtonSound();

            FullStoryController fullStoryController = new FullStoryController(_audioManager, _gameManager, _uiManager, _cardsSpriteManager);

            Dispose();
        }
        private void PlayAgain() 
        {
            ApplyButtonSound();

            _gameManager.GameState.Value = GameState.PlayAgain;
        }
        private void Menu() 
        {
            ApplyButtonSound();

            _gameManager.GameState.Value = GameState.Menu;
        }
        private void SimpleButtonSound() => _audioManager.SimpleClickAudioSource.Play();
        private void ApplyButtonSound() => _audioManager.ApplyClickAudioSource.Play();
    }
}