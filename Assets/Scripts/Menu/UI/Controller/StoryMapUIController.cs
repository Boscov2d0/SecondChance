using SecondChanse.Data;
using SecondChanse.Menu.Data;
using SecondChanse.Menu.Tools;
using SecondChanse.Menu.UI.View;
using SecondChanse.Tools;

namespace SecondChanse.Menu.UI.Controller
{
    public class StoryMapUIController : ObjectsDisposer
    {
        private readonly AudioManager _audioManager;
        private readonly PlayerProfile _playerProfile;
        private readonly GameManager _gameManager;
        public StoryMapUIController(AudioManager audioManager, PlayerProfile playerProfile, GameManager gameManager, UIManager uiManager) 
        {
            _audioManager = audioManager;
            _playerProfile = playerProfile;
            _gameManager = gameManager;

            StoryMapCanvasView storyMapCanvas = ResourcesLoader.InstantiateAndGetObject<StoryMapCanvasView>(uiManager.UIObjectsPath + uiManager.StoryMapCanvasPath);
            AddGameObject(storyMapCanvas.gameObject);
            storyMapCanvas.Initialize(StartCherryBlossomFestivalStory, Back);
        }
        private void StartCherryBlossomFestivalStory() 
        {
            ApplyButtonSound();

            _playerProfile.Story = Story.CherryBlossomFestival;
            _gameManager.State.Value = MenuState.LoadStory;
        }
        private void Back() 
        {
            ApplyButtonSound();
            _gameManager.State.Value = MenuState.Menu;
        }
        private void ApplyButtonSound() => _audioManager.ApplyClickAudioSource.Play();
    }
}