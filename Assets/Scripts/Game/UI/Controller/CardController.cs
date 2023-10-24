using SecondChanse.Data;
using SecondChanse.Game.Data;
using SecondChanse.Tools;
using UnityEngine;

using static SecondChanse.Game.Tools.States;

namespace SecondChanse.Game.UI.Controller
{
    public class CardController : ObjectsDisposer
    {
        private readonly AudioManager _audioManager;
        private readonly GameManager _gameManager;
        private readonly UIManager _uiManager;
        private readonly CardsSpriteManager _cardsSpriteManager;

        private CloseCardController _closeCardController;
        private OpenCardController _openCardController;
        private StoryCardController _storyCardController;

        private Transform _place;
        private int _cardIndex;

        public CardController(AudioManager audioManager, GameManager gameManager, 
                              UIManager uiManager, CardsSpriteManager cardsSpriteManager, 
                              Transform place, int cardIndex)
        {
            _audioManager = audioManager;
            _gameManager = gameManager;
            _uiManager = uiManager;
            _cardsSpriteManager = cardsSpriteManager;
            _place = place;
            _cardIndex = cardIndex;

            Createcard();
        }
        protected override void OnDispose()
        {
            _openCardController?.Dispose();
            _storyCardController?.Dispose();

            base.OnDispose();
        }
        private void Createcard()
        {
            _closeCardController = new CloseCardController(_audioManager, _gameManager, 
                                                           _uiManager, _cardsSpriteManager, 
                                                           _place, _cardIndex);
            AddController(_closeCardController);
            _closeCardController.Destroy += OnOpenCard;
        }
        public void FexidExecute()
        {
            _closeCardController?.FexidExecute();
            _storyCardController?.FixedExecute();
        }
        public void OnOpenCard()
        {
            SimpleButtonSound();
            _closeCardController?.Dispose();
            _closeCardController = null;
            _openCardController = new OpenCardController(_gameManager, _uiManager, _cardsSpriteManager, 
                                                         _place, _cardIndex);
            AddController(_openCardController);
            _openCardController.OnReadCard += ReadCard;
            _storyCardController = new StoryCardController(_audioManager, _gameManager, _uiManager, 
                                                           _cardsSpriteManager, _cardIndex);
            AddController(_storyCardController);
        }
        private void ReadCard()
        {
            if (_gameManager.GameState.Value != GameState.OpenCard)
            {
                SimpleButtonSound();
                _storyCardController.Initialize();
                _gameManager.GameState.Value = GameState.ReadStory;
            }
        }
        private void SimpleButtonSound() => _audioManager.SimpleClickAudioSource.Play();
    }
}