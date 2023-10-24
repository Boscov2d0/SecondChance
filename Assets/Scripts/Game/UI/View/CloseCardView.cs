using SecondChanse.Tools;
using SecondChanse.Data;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using SecondChanse.Game.Data;

namespace SecondChanse.Game.UI.View 
{
    public class CloseCardView : MonoBehaviour
    {
        [SerializeField] private LocalizationManager _localizationManager;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Text _timeText;
        [SerializeField] private Text _placeText;
        [SerializeField] private Text _dateText;
        [SerializeField] private Button _openCardButton;

        private UnityAction _openCard;
        private int _cardIndex;

        public void Initialize(CardsSpriteManager cardsSpriteManager, UnityAction openCard, int cardIndex)
        {
            _openCard = openCard;

            _openCardButton.onClick.AddListener(_openCard);

            _cardIndex = cardIndex;

            _backgroundImage.sprite = cardsSpriteManager.CloseCardSpirte;

            SetText();
        }
        private void OnDestroy()
        {
            _openCardButton.onClick.RemoveListener(_openCard);
        }
        private void SetText()
        {
            _timeText.text = Localizator.GetLocalizedValue(_localizationManager.CurrentCardsText, 
                LocalizationTextKeys.LocalizationCloseCardTextKeys.TimeCard + _cardIndex.ToString());
            _placeText.text = Localizator.GetLocalizedValue(_localizationManager.CurrentCardsText, 
                LocalizationTextKeys.LocalizationCloseCardTextKeys.PlaceCard + _cardIndex.ToString());
            _dateText.text = Localizator.GetLocalizedValue(_localizationManager.CurrentCardsText, 
                LocalizationTextKeys.LocalizationCloseCardTextKeys.DateCard + _cardIndex.ToString());
        }
    }
}