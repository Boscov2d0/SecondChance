using SecondChanse.Tools;
using SecondChanse.Game.Data;
using SecondChanse.Game.UI.Controller;
using SecondChanse.Data;
using UnityEngine.SceneManagement;

using static SecondChanse.Game.Tools.States;

namespace SecondChanse.Game.Core
{
    public class GameController : ObjectsDisposer
    {
        private readonly AudioManager _audioManager;
        private readonly GameManager _gameManager;
        private readonly UIManager _uiManager;
        private readonly CardsSpriteManager _cardsSpriteManager;

        private PlayBoardController _playBoardController;

        public GameController(AudioManager audioManager, GameManager gameManager, UIManager uiManager, CardsSpriteManager cardsSpriteManager)
        {
            _audioManager = audioManager;
            _gameManager = gameManager;
            _uiManager = uiManager;
            _cardsSpriteManager = cardsSpriteManager;

            _gameManager.CurrentCountOfCloseCard.Value = _gameManager.CountOfCloseCard;
            _gameManager.CurrentCountOfHint.Value = _gameManager.CountOfHint;

            _playBoardController = new PlayBoardController(_audioManager, _gameManager, _uiManager, cardsSpriteManager);
            AddController(_playBoardController);

            _gameManager.GameState.SubscribeOnChange(OnStateChange);
            _gameManager.CurrentCountOfCloseCard.SubscribeOnChange(EndGame);
        }
        protected override void OnDispose()
        {
            _gameManager.GameState.UnSubscribeOnChange(OnStateChange);
            _gameManager.CurrentCountOfCloseCard.UnSubscribeOnChange(EndGame);
            _playBoardController?.Dispose();

            base.OnDispose();
        }
        public void FixedExecute() 
        {
            _playBoardController?.FixedExecute();
        }
        private void OnStateChange() 
        {
            switch (_gameManager.GameState.Value) 
            {
                case GameState.PlayAgain:
                    PlayAgain();
                    break;
                case GameState.Menu:
                    LoadMenu();
                    break;
            }
        }
        private void EndGame() 
        {
            if (_gameManager.CurrentCountOfCloseCard.Value > 0)
                return;

            if (_gameManager.CountOfPoints.Value < 0)
                _gameManager.EndingState = EndingState.VeryBadEnd;
            if (_gameManager.CountOfPoints.Value >= 0 && _gameManager.CurrentCountOfCloseCard.Value <= 4)
                _gameManager.EndingState = EndingState.BadEnd;
            if (_gameManager.CountOfPoints.Value >= 5 && _gameManager.CurrentCountOfCloseCard.Value <= 7)
                _gameManager.EndingState = EndingState.NoChangeEnd;
            if (_gameManager.CountOfPoints.Value >= 8 && _gameManager.CurrentCountOfCloseCard.Value <= 9)
                _gameManager.EndingState = EndingState.NormalEnd;
            if (_gameManager.CountOfPoints.Value >= 10 && _gameManager.CurrentCountOfCloseCard.Value <= 11)
                _gameManager.EndingState = EndingState.GoodEnd;
            if (_gameManager.CountOfPoints.Value >= 12)
                _gameManager.EndingState = EndingState.VeryGoodEnd;

            EndingController endingController = new EndingController(_audioManager, _gameManager, _uiManager, _cardsSpriteManager);
        }
        private void PlayAgain()
        {
            SceneManager.LoadScene(Keys.SceneNameKeys.Game.ToString());
        }
        private void LoadMenu() =>  SceneManager.LoadScene(Keys.SceneNameKeys.Menu.ToString());
    }
}