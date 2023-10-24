using SecondChanse.Data;
using SecondChanse.Game.Data;
using SecondChanse.Game.UI.View;
using SecondChanse.Tools;
using System.Collections.Generic;
using UnityEngine;

using static SecondChanse.Game.Tools.States;

namespace SecondChanse.Game.UI.Controller
{
    public class PlayBoardController : ObjectsDisposer
    {
        private readonly AudioManager _audioManager;
        private readonly GameManager _gameManager;
        private readonly UIManager _uiManager;
        private readonly CardsSpriteManager _cardsSpriteManager;

        private List<CardController> _cardControllers = new List<CardController>();
        private List<Transform> _cardPlaces = new List<Transform>();

        public PlayBoardController(AudioManager audioManager, GameManager gameManager, UIManager uiManager, CardsSpriteManager cardsSpriteManager)
        {
            _audioManager = audioManager;
            _gameManager = gameManager;
            _uiManager = uiManager;
            _cardsSpriteManager = cardsSpriteManager;

            CreateBoard();
            PutCardsOnTable();
        }
        protected override void OnDispose()
        {
            for (int i = 0; i < _cardControllers.Count; i++) 
            {
                _cardControllers[i]?.Dispose();
            }
            _cardControllers?.Clear();

            base.OnDispose();
        }
        private void CreateBoard() 
        {
            PlayBoardCanvasView playBoardCanvas = ResourcesLoader.InstantiateAndGetObject<PlayBoardCanvasView>(_uiManager.UIObjectsPath + _uiManager.PlayBoatdCanvasPath);
            AddGameObject(playBoardCanvas.gameObject);
            playBoardCanvas.Initialize(_gameManager, PlayMusic, MuteMusic, Menu);

            for (int i = 0; i < playBoardCanvas.UpperCardPlaces.Count; i++)
            {
                _cardPlaces.Add(playBoardCanvas.UpperCardPlaces[i]);
            }
            for (int i = 0; i < playBoardCanvas.DownardPlaces.Count; i++)
            {
                _cardPlaces.Add(playBoardCanvas.DownardPlaces[i]);
            }
        }
        private void PutCardsOnTable()
        {
            for (int i = 0; i < _gameManager.CountOfCard; i++)
            {
                CardController cardController = new CardController(_audioManager, _gameManager, _uiManager, _cardsSpriteManager, _cardPlaces[i], i+1);
                AddController(cardController);
                _cardControllers.Add(cardController);

                if (i == _gameManager.FirstCardNumber-1) 
                {
                    cardController.OnOpenCard();
                }
            }
        }
        public void FixedExecute()
        {
            for (int i = 0; i < _cardControllers.Count; i++)
            {
                _cardControllers[i]?.FexidExecute();
            }
        }
        private void PlayMusic() 
        {
            SimpleButtonSound();

            _audioManager.AudioMixer.SetFloat(Keys.AudioKeys.Sound.ToString(), Mathf.Log10(_audioManager.SoundsValue) * 20);
            _audioManager.AudioMixer.SetFloat(Keys.AudioKeys.Music.ToString(), Mathf.Log10(_audioManager.MusicValue) * 20);
        }
        private void MuteMusic() 
        {
            SimpleButtonSound();

            _audioManager.AudioMixer.SetFloat(Keys.AudioKeys.Sound.ToString(), -80);
            _audioManager.AudioMixer.SetFloat(Keys.AudioKeys.Music.ToString(), -80);
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