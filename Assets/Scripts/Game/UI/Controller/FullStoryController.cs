using SecondChanse.Data;
using SecondChanse.Game.Data;
using SecondChanse.Game.UI.View;
using SecondChanse.Tools;

using static SecondChanse.Game.Tools.States;

namespace SecondChanse.Game.UI.Controller
{
    public class FullStoryController : ObjectsDisposer
    {
        private readonly AudioManager _audioManager;
        private readonly GameManager _gameManager;
        private readonly UIManager _uiManager;
        private readonly CardsSpriteManager _cardsSpriteManager;

        public FullStoryController(AudioManager audioManager, GameManager gameManager, UIManager uiManager, CardsSpriteManager cardsSpriteManager) 
        {
            _audioManager = audioManager;
            _gameManager = gameManager;
            _uiManager = uiManager;
            _cardsSpriteManager = cardsSpriteManager;

            FullStoryCanvasView fullStoryCanvas = ResourcesLoader.InstantiateAndGetObject<FullStoryCanvasView>(uiManager.UIObjectsPath + uiManager.FullStoryCanvasPath);
            AddGameObject(fullStoryCanvas.gameObject);
            fullStoryCanvas.Initialize(cardsSpriteManager, ReadImportantDecisions, PlayAgain, Menu);
        }
        private void ReadImportantDecisions() 
        {
            SimpleButtonSound();

            ImportantDecisionsController importantDecisionsController = new ImportantDecisionsController(_audioManager, _gameManager, _uiManager, _cardsSpriteManager);

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