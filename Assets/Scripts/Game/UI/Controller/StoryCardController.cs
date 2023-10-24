using SecondChanse.Data;
using SecondChanse.Game.Data;
using SecondChanse.Game.UI.View;
using SecondChanse.Tools;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace SecondChanse.Game.UI.Controller
{
    public class StoryCardController : ObjectsDisposer
    {
        private readonly AudioManager _audioManager;
        private readonly GameManager _gameManager;
        private readonly UIManager _uiManager;
        private readonly CardsSpriteManager _cardsSpriteManager;

        private StoryCardCanvasView _storyCard;
        private bool _hintIsOpen;
        private bool _showHint;
        private bool _answered;
        private int _cardIndex;

        private Dictionary<string, string> _answersPoints;
        private int _answersPointResult;

        public StoryCardController(AudioManager audioManager, GameManager gameManager, UIManager uiManager, CardsSpriteManager ardsSpriteManager, int cardIndex)
        {
            _audioManager = audioManager;
            _gameManager = gameManager;
            _uiManager = uiManager;
            _cardsSpriteManager = ardsSpriteManager;
            _cardIndex = cardIndex;

            if (_cardIndex == _gameManager.FirstCardNumber || _cardIndex == _gameManager.CountOfCard)
                _answered = true;

            Initialize();
        }
        public void Initialize()
        {
            _storyCard = ResourcesLoader.InstantiateAndGetObject<StoryCardCanvasView>(_uiManager.UIObjectsPath + _uiManager.StoryCardCanvasPath);
            AddGameObject(_storyCard.gameObject);
            _storyCard.Initialize(_gameManager, _cardsSpriteManager, CloseStory, _cardIndex, _answered, _answersPointResult);

            if (_cardIndex != _gameManager.FirstCardNumber && _cardIndex != _gameManager.CountOfCard)
            {
                CreateAnswersPointsDictionary();

                for (int i = 0; i < _storyCard.SelectionButtons.Count; i++)
                {
                    _storyCard.SelectionButtons[i].Initialize(int.Parse(_answersPoints[_storyCard.SelectionButtons[i].AnswerType.ToString()]));
                    _storyCard.SelectionButtons[i].Button.onClick.AddListener(GetAnswer);
                    _storyCard.SelectionButtons[i].Button.onClick.AddListener(SimpleButtonSound);

                    if (_answered && _storyCard.SelectionButtons[i].AnswersPointResult == _answersPointResult)
                        _storyCard.SelectionButtons[i].SetButtonColor();
                }
            }
            else
                OpenHint();

            if (!_hintIsOpen)
            {
                _storyCard.HintButton.onClick.AddListener(OpenHint);
                _storyCard.HintButton.onClick.AddListener(SimpleButtonSound);
            }
            else
            {
                _storyCard.HintText.gameObject.SetActive(true);
                _storyCard.HintText.color = new Color(255.0f, 0.0f, 0.0f, 1f);
            }
        }
        protected override void OnDispose()
        {
            _storyCard.HintButton.onClick.RemoveListener(OpenHint);
            _storyCard.HintButton.onClick.RemoveListener(SimpleButtonSound);

            for (int i = 0; i < _storyCard.SelectionButtons.Count; i++)
            {
                _storyCard.SelectionButtons[i].Button.onClick.RemoveListener(GetAnswer);
                _storyCard.SelectionButtons[i].Button.onClick.RemoveListener(SimpleButtonSound);
            }

            base.OnDispose();
        }
        public void FixedExecute()
        {
            if (!_showHint)
                return;

            if (_storyCard.HintText.color.a < 1f)
                _storyCard.HintText.color += new Color(255.0f, 0.0f, 0.0f, 0.01f);
            else
                _showHint = false;
        }
        private void CreateAnswersPointsDictionary()
        {
            _answersPoints = new Dictionary<string, string>();

            if (_cardIndex != 12 && _cardIndex != 13)
            {
                for (int i = 0; i < _gameManager.RightChoices[_cardIndex - 1].Choice.Count; i++)
                {
                    _answersPoints[_gameManager.RightChoices[_cardIndex - 1].Choice[i]] = _gameManager.RightChoices[_cardIndex - 1].Result[i];
                }
            }
        }
        private void OpenHint()
        {
            if (_gameManager.CurrentCountOfHint.Value > 0 && !_hintIsOpen)
            {
                _storyCard.HintText.gameObject.SetActive(true);
                _showHint = true;
                _hintIsOpen = true;
                _gameManager.CurrentCountOfHint.Value--;
                _storyCard.HintButton.enabled = false;
            }
        }
        private void CloseStory()
        {
            if (!_showHint && _answered)
            {
                if (_gameManager.OpenCardsIndex.Contains(_cardIndex))
                {
                    _gameManager.CurrentCountOfCloseCard.Value--;
                    _gameManager.OpenCardsIndex.Remove(_cardIndex);
                }

                SimpleButtonSound();
                GameObject.Destroy(_storyCard.gameObject);
            }
        }
        private void GetAnswer()
        {
            _answersPointResult = int.Parse(_answersPoints[_gameManager.CurrentAnswerType.ToString()]);
            _gameManager.CountOfPoints.Value += _answersPointResult;

            _storyCard.ShowResult(_answersPointResult);

            _answered = true;
        }
        private void SimpleButtonSound() => _audioManager.SimpleClickAudioSource.Play();
    }
}