using SecondChanse.Data;
using SecondChanse.Game.Data;
using SecondChanse.Game.UI.View;
using SecondChanse.Tools;
using System;
using UnityEngine;

using static SecondChanse.Game.Tools.States;

namespace SecondChanse.Game.UI.Controller
{
    public class CloseCardController : ObjectsDisposer
    {
        private readonly AudioManager _audioManager;
        private readonly GameManager _gameManager;
        private readonly CloseCardView _closeCardView;

        private Transform _place;
        private int _cardIndex;
        private bool _rotate;

        public Action Destroy;

        public CloseCardController(AudioManager audioManager, GameManager gameManager, UIManager uiManager, CardsSpriteManager cardsSpriteManager, Transform place, int cardIndex) 
        {
            _audioManager = audioManager;
            _gameManager = gameManager;
            _place = place;
            _cardIndex = cardIndex;

            _closeCardView = ResourcesLoader.InstantiateAndGetObject<CloseCardView>(uiManager.UIObjectsPath + uiManager.CloseCardPath, _place);
            AddGameObject(_closeCardView.gameObject);
            _closeCardView.Initialize(cardsSpriteManager, OpenCard, _cardIndex);
        }
        public void FexidExecute()
        {
             if (_rotate)
                OpenCardAnimation();
        }
        private void OpenCard()
        {
            if (_gameManager.GameState.Value != GameState.OpenCard)
            {
                SimpleButtonSound();
                _rotate = true;
                _gameManager.GameState.Value = GameState.OpenCard;
            }
        }
        private void OpenCardAnimation()
        {
            _closeCardView.gameObject.transform.Rotate(0.0f, 15.0f, 0.0f);
            _closeCardView.gameObject.transform.localScale += new Vector3(0.007f, 0.007f, 0.0f);

            if (_closeCardView.gameObject.transform.localScale.x >= 1.5f)
            {
                _rotate = false;
                Destroy?.Invoke();
            }
        }
        private void SimpleButtonSound() => _audioManager.SimpleClickAudioSource.Play();
    }
}