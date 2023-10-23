using SecondChanse.Data;
using SecondChanse.Game.Data;
using SecondChanse.Game.UI.View;
using SecondChanse.Tools;

using static SecondChanse.Game.Tools.States;

namespace SecondChanse.Game.UI.Controller
{
    public class ImportantDecisionsController : ObjectsDisposer
    {
        private readonly AudioManager _audioManager;
        private readonly GameManager _gameManager;
        
        public ImportantDecisionsController(AudioManager audioManager, GameManager gameManager, UIManager uiManager, CardsSpriteManager cardsSpriteManager) 
        {
            _audioManager = audioManager;
            _gameManager = gameManager;

            ImportantDecisionsCanvasView importantDecisionsCanvas = ResourcesLoader.InstantiateAndGetObject<ImportantDecisionsCanvasView>(uiManager.UIObjectsPath + uiManager.ImportantDecisionsCanvasPath);
            AddGameObject(importantDecisionsCanvas.gameObject);
            importantDecisionsCanvas.Initialize(cardsSpriteManager, PlayAgain, Menu);
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
        private void ApplyButtonSound() => _audioManager.ApplyClickAudioSource.Play();
    }
}