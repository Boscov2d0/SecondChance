using SecondChanse.Data;
using SecondChanse.Game.Data;
using SecondChanse.Tools;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using LFSTK = SecondChanse.Tools.LocalizationTextKeys.LocalizationFullStoryTextKeys;

namespace SecondChanse.Game.UI.View
{
    public class FullStoryCanvasView : MonoBehaviour
    {
        [SerializeField] private LocalizationManager _localizationManager;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Text _fullStory;
        [SerializeField] private Text _readDesitionText;
        [SerializeField] private Text _playAgainText;
        [SerializeField] private Text _menuText;
        [SerializeField] private Button _readDesitionButton;
        [SerializeField] private Button _playAgainButton;
        [SerializeField] private Button _menuButton;

        private UnityAction _readDesition;
        private UnityAction _playAgain;
        private UnityAction _menu;

        public void Initialize(CardsSpriteManager cardsSpriteManager, UnityAction readDesition, UnityAction playAgain, UnityAction menu)
        {
            _readDesition = readDesition;
            _playAgain = playAgain;
            _menu = menu;

            _readDesitionButton.onClick.AddListener(_readDesition);
            _playAgainButton.onClick.AddListener(_playAgain);
            _menuButton.onClick.AddListener(_menu);

            _backgroundImage.sprite = cardsSpriteManager.FullStorySprite;

            TranslateText();
        }
        private void OnDestroy()
        {
            _readDesitionButton.onClick.RemoveListener(_readDesition);
            _playAgainButton.onClick.RemoveListener(_playAgain);
            _menuButton.onClick.RemoveListener(_menu);
        }
        private void TranslateText()
        {
            _fullStory.text = Localizator.GetLocalizedValue(_localizationManager.CurrentCardsText, LFSTK.FullStory);
            _readDesitionText.text = Localizator.GetLocalizedValue(_localizationManager.GameText, LFSTK.ReadImportantDecisions);
            _playAgainText.text = Localizator.GetLocalizedValue(_localizationManager.GameText, LFSTK.PlayAgain);
            _menuText.text = Localizator.GetLocalizedValue(_localizationManager.GameText, LFSTK.Menu);
        }
    }
}