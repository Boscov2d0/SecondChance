using SecondChanse.Data;
using SecondChanse.Menu.Data;
using SecondChanse.Menu.UI.View;
using SecondChanse.Tools;

namespace SecondChanse.Menu.UI.Controller
{
    public class MenuUIController : ObjectsDisposer
    {
        private readonly AudioManager _audioManager;
        private readonly GameManager _gameManager;

        public MenuUIController(AudioManager audioManager, GameManager gameManager, UIManager uiManager) 
        {
            _audioManager = audioManager;
            _gameManager = gameManager;

            MenuCanvasView menuCanvas = ResourcesLoader.InstantiateAndGetObject<MenuCanvasView>(uiManager.UIObjectsPath + uiManager.MenuCanvasPath);
            AddGameObject(menuCanvas.gameObject);
            menuCanvas.Initialize(ChooseStory, Rules, Settings, Exit);
        }

        private void ChooseStory()
        {
            ApplyButtonSound();
            _gameManager.State.Value = Tools.MenuState.StoryMap;
        }
        private void Rules()
        {
            SimpleButtonSound();
            _gameManager.State.Value = Tools.MenuState.Rules;
        }
        private void Settings()
        {
            SimpleButtonSound();
            _gameManager.State.Value = Tools.MenuState.Settings;
        }
        private void Exit()
        {
            ApplyButtonSound();
            _gameManager.State.Value = Tools.MenuState.Exit;
        }
        private void SimpleButtonSound() => _audioManager.SimpleClickAudioSource.Play();
        private void ApplyButtonSound() => _audioManager.ApplyClickAudioSource.Play();
    }
}