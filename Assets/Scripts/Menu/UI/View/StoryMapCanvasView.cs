using SecondChanse.Data;
using SecondChanse.Tools;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SecondChanse.Menu.UI.View
{
    public class StoryMapCanvasView : MonoBehaviour
    {
        [SerializeField] private LocalizationManager _localizationManager;
        [SerializeField] private Text _backText;
        [SerializeField] private Button _backButton;

        private UnityAction _back;

        public void Initialize(UnityAction back)
        {
            _back = back;

            _backButton.onClick.AddListener(_back);

            TranslateText();
        }
        private void OnDestroy()
        {
            _backButton.onClick.RemoveListener(_back);
        }
        private void TranslateText()
        {
            _backText.text = Localizator.GetLocalizedValue(_localizationManager.StoryMapText, LocalizationTextKeys.LocalizationStoryMapTextKeys.Back);
        }
    }
}