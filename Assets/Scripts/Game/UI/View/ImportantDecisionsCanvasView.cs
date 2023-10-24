using SecondChanse.Data;
using SecondChanse.Game.Data;
using SecondChanse.Tools;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using LIDTK = SecondChanse.Tools.LocalizationTextKeys.LocalizationImportantDecisionsTextKeys;

namespace SecondChanse.Game.UI.View
{
    public class ImportantDecisionsCanvasView : MonoBehaviour
    {
        [SerializeField] private LocalizationManager _localizationManager;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Text _importantDecisionsText;
        [SerializeField] private Text _playAgainText;
        [SerializeField] private Text _menuText;
        [SerializeField] private Button _playAgainButton;
        [SerializeField] private Button _menuButton;

        private UnityAction _playAgain;
        private UnityAction _menu;

        public void Initialize(CardsSpriteManager cardsSpriteManager, UnityAction playAgain, UnityAction menu)
        {
            _playAgain = playAgain;
            _menu = menu;

            _playAgainButton.onClick.AddListener(_playAgain);
            _menuButton.onClick.AddListener(_menu);

            _backgroundImage.sprite = cardsSpriteManager.ImportantDecisionsSprite;

            TranslateText();
        }
        private void OnDestroy()
        {
            _playAgainButton.onClick.RemoveListener(_playAgain);
            _menuButton.onClick.RemoveListener(_menu);
        }
        private void TranslateText()
        {
            _importantDecisionsText.text = Localizator.GetLocalizedValue(_localizationManager.CurrentCardsText, LIDTK.ImportantDecisions);
            _playAgainText.text = Localizator.GetLocalizedValue(_localizationManager.GameText, LIDTK.PlayAgain);
            _menuText.text = Localizator.GetLocalizedValue(_localizationManager.GameText, LIDTK.Menu);
        }
    }
}