using SecondChanse.Data;
using SecondChanse.Game.Data;
using SecondChanse.Tools;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using static SecondChanse.Game.Tools.States;
using LETK = SecondChanse.Tools.LocalizationTextKeys.LocalizationEndingsTextKeys;

namespace SecondChanse.Game.UI.View
{
    public class EndingCanvasView : MonoBehaviour
    {
        [SerializeField] private LocalizationManager _localizationManager;
        [SerializeField] private Image _background;
        [SerializeField] private Image _image;
        [SerializeField] private Text _resultText;
        [SerializeField] private Text _readFullStoryText;
        [SerializeField] private Text _playAgainText;
        [SerializeField] private Text _menuText;
        [SerializeField] private Button _readFullStoryButton;
        [SerializeField] private Button _playAgainButton;
        [SerializeField] private Button _menuButton;

        private GameManager _gameManager;
        private CardsSpriteManager _cardsSpriteManager;

        private UnityAction _readFullStory;
        private UnityAction _playAgain;
        private UnityAction _mainMenu;

        public void Initialize(GameManager gameManager, CardsSpriteManager cardsSpriteManager, 
                               UnityAction readFullStory, UnityAction playAgain, UnityAction mainMenu)
        {
            _gameManager = gameManager;
            _cardsSpriteManager = cardsSpriteManager;
            _readFullStory = readFullStory;
            _playAgain = playAgain;
            _mainMenu = mainMenu;

            _readFullStoryButton.onClick.AddListener(_readFullStory);
            _playAgainButton.onClick.AddListener(_playAgain);
            _menuButton.onClick.AddListener(_mainMenu);

            TranslateText();

            SetImage();
            SetButtons();
        }
        private void OnDestroy()
        {
            _readFullStoryButton.onClick.RemoveListener(_readFullStory);
            _playAgainButton.onClick.RemoveListener(_playAgain);
            _menuButton.onClick.RemoveListener(_mainMenu);
        }
        private void SetImage() 
        {
            switch (_gameManager.EndingState) 
            {
                case EndingState.VeryBadEnd:
                    _background.color = _cardsSpriteManager.VeryBadEndColor;
                    _image.sprite = _cardsSpriteManager.VeryBadEndSprite;
                    break;
                case EndingState.BadEnd:
                    _background.color = _cardsSpriteManager.BadEndColor;
                    _image.sprite = _cardsSpriteManager.BadEndSprite;
                    break;
                case EndingState.NoChangeEnd:
                    _background.color = _cardsSpriteManager.NoChangeEndColor;
                    _image.sprite = _cardsSpriteManager.NoChangeEndSprite;
                    break;
                case EndingState.NormalEnd:
                    _background.color = _cardsSpriteManager.NormalEndColor;
                    _image.sprite = _cardsSpriteManager.NormalEndSprite;
                    break;
                case EndingState.GoodEnd:
                    _background.color = _cardsSpriteManager.GoodEndColor;
                    _image.sprite = _cardsSpriteManager.GoodEndSprite;
                    break;
                case EndingState.VeryGoodEnd:
                    _background.color = _cardsSpriteManager.VeryGoodEndColor;
                    _image.sprite = _cardsSpriteManager.VeryGoodEndSprite;
                    break;
            }
        }
        private void SetButtons() 
        {
            if (_gameManager.EndingState == EndingState.VeryBadEnd || 
                _gameManager.EndingState == EndingState.BadEnd || 
                _gameManager.EndingState == EndingState.NoChangeEnd)
                _readFullStoryButton.enabled = false;
        }
        private void TranslateText()
        {
            switch (_gameManager.EndingState)
            {
                case EndingState.VeryBadEnd:
                    _resultText.text = Localizator.GetLocalizedValue(_localizationManager.GameText, LETK.VeryBadEnd);
                    _readFullStoryText.text = Localizator.GetLocalizedValue(_localizationManager.GameText, LETK.CantReadStory);
                    break;
                case EndingState.BadEnd:
                    _resultText.text = Localizator.GetLocalizedValue(_localizationManager.GameText, LETK.BadEnd);
                    _readFullStoryText.text = Localizator.GetLocalizedValue(_localizationManager.GameText, LETK.CantReadStory);
                    break;
                case EndingState.NoChangeEnd:
                    _resultText.text = Localizator.GetLocalizedValue(_localizationManager.GameText, LETK.NoChangeEnd);
                    _readFullStoryText.text = Localizator.GetLocalizedValue(_localizationManager.GameText, LETK.CantReadStory);
                    break;
                case EndingState.NormalEnd:
                    _resultText.text = Localizator.GetLocalizedValue(_localizationManager.GameText, LETK.NormalEnd);
                    _readFullStoryText.text = Localizator.GetLocalizedValue(_localizationManager.GameText, LETK.ReadStory);
                    break;
                case EndingState.GoodEnd:
                    _resultText.text = Localizator.GetLocalizedValue(_localizationManager.GameText, LETK.GoodEnd);
                    _readFullStoryText.text = Localizator.GetLocalizedValue(_localizationManager.GameText, LETK.ReadStory);
                    break;
                case EndingState.VeryGoodEnd:
                    _resultText.text = Localizator.GetLocalizedValue(_localizationManager.GameText, LETK.VeryGoodEnd);
                    _readFullStoryText.text = Localizator.GetLocalizedValue(_localizationManager.GameText, LETK.ReadStory);
                    break;
            }

            _playAgainText.text = Localizator.GetLocalizedValue(_localizationManager.GameText, LETK.PlayAgain);
            _menuText.text = Localizator.GetLocalizedValue(_localizationManager.GameText, LETK.Menu);
        }
    }
}