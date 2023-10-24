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
        [SerializeField] private Text _cherryBlossomFestivalStoryText;
        [SerializeField] private Text _backText;
        [SerializeField] private Button _cherryBlossomFestivalStoryButton;
        [SerializeField] private Button _backButton;

        private UnityAction _cherryBlossomFestivalStory;
        private UnityAction _back;

        public void Initialize(UnityAction cherryBlossomFestivalStory, UnityAction back)
        {
            _cherryBlossomFestivalStory = cherryBlossomFestivalStory;
            _back = back;

            _cherryBlossomFestivalStoryButton.onClick.AddListener(_cherryBlossomFestivalStory);
            _backButton.onClick.AddListener(_back);

            TranslateText();
        }
        private void OnDestroy()
        {
            _cherryBlossomFestivalStoryButton.onClick.RemoveListener(_cherryBlossomFestivalStory);
            _backButton.onClick.RemoveListener(_back);
        }
        private void TranslateText()
        {
            _cherryBlossomFestivalStoryText.text = Localizator.GetLocalizedValue(_localizationManager.StoryMapText, LocalizationTextKeys.LocalizationStoryMapTextKeys.CherryBlossomFestivalStoryInfo);
            _backText.text = Localizator.GetLocalizedValue(_localizationManager.StoryMapText, LocalizationTextKeys.LocalizationStoryMapTextKeys.Back);
        }
    }
}