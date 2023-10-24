using SecondChanse.Data;
using SecondChanse.Menu.Data;
using SecondChanse.Menu.Tools;
using SecondChanse.Menu.UI.View;
using SecondChanse.Tools;

namespace SecondChanse.Menu.UI.Controller
{
    public class RulesUIController : ObjectsDisposer
    {
        private readonly AudioManager _audioManager;
        private readonly GameManager _gameManager;
        private readonly RulesCanvasView _rulesCanvas;

        private int _pageNumber;

        public RulesUIController(AudioManager audioManager, GameManager gameManager, UIManager uiManager)
        {
            _audioManager = audioManager;
            _gameManager = gameManager;

            _rulesCanvas = ResourcesLoader.InstantiateAndGetObject<RulesCanvasView>(uiManager.UIObjectsPath + uiManager.RulesCanvasPath);
            AddGameObject(_rulesCanvas.gameObject);
            _rulesCanvas.Initialize(NextPage, PrevPage, Menu);
        }
        private void NextPage()
        {
            SimpleButtonSound();

            _rulesCanvas.PrevPageButton.gameObject.SetActive(true);

            _rulesCanvas.Pages[_pageNumber].gameObject.SetActive(false);
            _pageNumber++;
            _rulesCanvas.Pages[_pageNumber].gameObject.SetActive(true);

            if (_pageNumber == _rulesCanvas.Pages.Count - 1)
                _rulesCanvas.NextPageButton.gameObject.SetActive(false);
        }
        private void PrevPage()
        {
            SimpleButtonSound();

            _rulesCanvas.NextPageButton.gameObject.SetActive(true);

            _rulesCanvas.Pages[_pageNumber].gameObject.SetActive(false);
            _pageNumber--;
            _rulesCanvas.Pages[_pageNumber].gameObject.SetActive(true);

            if (_pageNumber == 0)
                _rulesCanvas.PrevPageButton.gameObject.SetActive(false);
        }
        private void Menu()
        {
            ApplyButtonSound();
            _gameManager.State.Value = MenuState.Menu;
        }
        private void SimpleButtonSound() => _audioManager.SimpleClickAudioSource.Play();
        private void ApplyButtonSound() => _audioManager.ApplyClickAudioSource.Play();
    }
}