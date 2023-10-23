using SecondChanse.Data;
using SecondChanse.Game.Data;
using SecondChanse.Tools;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SecondChanse.Game.UI.View 
{
    public class OpenCardView : MonoBehaviour
    {
        [SerializeField] private LocalizationManager _localizationManager;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Text _text;
        [SerializeField] private Button _openButton;

        private UnityAction _readStory;
        private int _cardIndex;

        public void Initialize(CardsSpriteManager cardsSpriteManager, UnityAction readStory, int cardIndex)
        {
            _readStory = readStory;
            _cardIndex = cardIndex;

            _backgroundImage.sprite = cardsSpriteManager.OpenCardSpirte;

            _openButton.onClick.AddListener(_readStory);

            SetText();
        }
        private void OnDestroy()
        {
            _openButton.onClick.RemoveListener(_readStory);
        }
        private void SetText() 
        {
            _text.text = Localizator.GetLocalizedValue(_localizationManager.CurrentCardsText, 
                LocalizationTextKeys.LocalizationOpenCardTextKeys.OpenCard + _cardIndex.ToString());
        }
    }
}