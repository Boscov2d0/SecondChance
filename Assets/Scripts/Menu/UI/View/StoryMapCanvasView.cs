using SecondChanse.Data;
using SecondChanse.Tools;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using LSMTK = SecondChanse.Tools.LocalizationTextKeys.LocalizationStoryMapTextKeys;

namespace SecondChanse.Menu.UI.View
{
    public class StoryMapCanvasView : MonoBehaviour
    {
        [SerializeField] private LocalizationManager _localizationManager;
        [SerializeField] private Text _cherryBlossomFestivalStoryText;
        [SerializeField] private Text _bloodInTheGutterStoryText;
        [SerializeField] private Text _backText;
        [SerializeField] private Button _cherryBlossomFestivalStoryButton;
        [SerializeField] private Button _bloodInTheGutterStoryButton;
        [SerializeField] private Button _backButton;

        private UnityAction _cherryBlossomFestivalStory;
        private UnityAction _bloodInTheGutterStory;
        private UnityAction _back;

        public void Initialize(UnityAction cherryBlossomFestivalStory, UnityAction bloodInTheGutterStory, UnityAction back)
        {
            _cherryBlossomFestivalStory = cherryBlossomFestivalStory;
            _bloodInTheGutterStory = bloodInTheGutterStory;
            _back = back;

            _cherryBlossomFestivalStoryButton.onClick.AddListener(_cherryBlossomFestivalStory);
            _bloodInTheGutterStoryButton.onClick.AddListener(_bloodInTheGutterStory);
            _backButton.onClick.AddListener(_back);

            TranslateText();
        }
        private void OnDestroy()
        {
            _cherryBlossomFestivalStoryButton.onClick.RemoveListener(_cherryBlossomFestivalStory);
            _bloodInTheGutterStoryButton.onClick.RemoveListener(_bloodInTheGutterStory);
            _backButton.onClick.RemoveListener(_back);
        }
        private void TranslateText()
        {
            _cherryBlossomFestivalStoryText.text = Localizator.GetLocalizedValue(_localizationManager.StoryMapText, LSMTK.CherryBlossomFestivalStoryInfo);
            _bloodInTheGutterStoryText.text = Localizator.GetLocalizedValue(_localizationManager.StoryMapText, LSMTK.BloodInTheGutterStoryInfo);
            _backText.text = Localizator.GetLocalizedValue(_localizationManager.StoryMapText, LSMTK.Back);
        }
    }
}