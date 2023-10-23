using SecondChanse.Data;
using SecondChanse.Game.Data;
using SecondChanse.Tools;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using LSTK = SecondChanse.Tools.LocalizationTextKeys.LocalizationStoryCardTextKeys;
using LGTK = SecondChanse.Tools.LocalizationTextKeys.LocalizationGameTextKeys;

namespace SecondChanse.Game.UI.View
{
    public class StoryCardCanvasView : MonoBehaviour
    {
        [SerializeField] private LocalizationManager _localizationManager;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Image _closeButtonImage;
        [SerializeField] private Text _storyText;
        [SerializeField] private Text _questionText;
        [SerializeField] private Text _hintText;
        [SerializeField] private Text _negativResultText;
        [SerializeField] private Text _positivResultText;
        [SerializeField] private Text _neitralResultText;
        [SerializeField] private Button _hintButton;
        [SerializeField] private Button _closeButton;
        [SerializeField] private List<SelectionButton> _selectionButtons;

        private GameManager _gameManager;
        private UnityAction _closeStory;
        private int _cardIndex;

        public Text HintText => _hintText;
        public Button HintButton => _hintButton;
        public List<SelectionButton> SelectionButtons => _selectionButtons;
        public Text NegativResultText => _negativResultText;
        public Text PositivResultText => _positivResultText;
        public Text NeitralResultText => _neitralResultText;

        public void Initialize(GameManager gameManager, CardsSpriteManager cardsSpriteManager, UnityAction closeStory, 
                               int cardIndex, bool answered, int answersPointResult)
        {
            _gameManager = gameManager;
            _closeStory = closeStory;
            _cardIndex = cardIndex;

            _closeButton.onClick.AddListener(_closeStory);

            _backgroundImage.sprite = cardsSpriteManager.StoryCardSpirte;
            _closeButtonImage.sprite = cardsSpriteManager.CloseStoryCardButtonSpirte;

            TranslateText();

            if (answered)
                ShowResult(answersPointResult);
        }
        private void OnDestroy()
        {
            _closeButton.onClick.RemoveListener(_closeStory);
        }
        private void TranslateText()
        {
            _storyText.text = Localizator.GetLocalizedValue(_localizationManager.CurrentCardsText,
                              LSTK.StoryCard + _cardIndex.ToString());
            if (_cardIndex != _gameManager.FirstCardNumber)
                _questionText.text = Localizator.GetLocalizedValue(_localizationManager.CurrentCardsText,
                                     LSTK.QuestionCard + _cardIndex.ToString());
            if (_cardIndex != _gameManager.CountOfCard)
                _hintText.text = Localizator.GetLocalizedValue(_localizationManager.CurrentCardsText,
                                 LSTK.HintCard + _cardIndex.ToString());

            if (_cardIndex != _gameManager.FirstCardNumber && _cardIndex != _gameManager.CountOfCard)
            {
                for (int i = 0; i < _selectionButtons.Count; i++)
                {
                    _selectionButtons[i].Text.text = Localizator.GetLocalizedValue(_localizationManager.CurrentCardsText,
                                                     LSTK.Answer + _selectionButtons[i].AnswerType.ToString() +
                                                     LSTK.Card + _cardIndex.ToString());
                }
            }

            _negativResultText.text = Localizator.GetLocalizedValue(_localizationManager.GameText,
                                      LGTK.NegativeResult);
            _positivResultText.text = Localizator.GetLocalizedValue(_localizationManager.GameText,
                                      LGTK.PositiveResult);
            _neitralResultText.text = Localizator.GetLocalizedValue(_localizationManager.GameText,
                                      LGTK.NeitralResult);
        }
        public void ShowResult(int answersPointResult)
        {
            for (int i = 0; i < _selectionButtons.Count; i++)
                _selectionButtons[i].Button.enabled = false;

            if (_cardIndex == _gameManager.FirstCardNumber || _cardIndex == _gameManager.CountOfCard)
                return;

            switch (answersPointResult)
            {
                case > 0:
                    _positivResultText.gameObject.SetActive(true);
                    break;
                case 0:
                    _neitralResultText.gameObject.SetActive(true);
                    break;
                case < 0:
                    _negativResultText.gameObject.SetActive(true);
                    break;
            }
        }
    }
}