using SecondChanse.Data;
using SecondChanse.Tools;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SecondChanse.Menu.UI.View
{
    public class MenuCanvasView : MonoBehaviour
    {
        [SerializeField] private LocalizationManager _localizationManager;
        [SerializeField] private AudioManager _audioManager;
        [SerializeField] private Text _hellowText;
        [SerializeField] private Text _licenseText;
        [SerializeField] private Text _chooseStoryText;
        [SerializeField] private Text _settingsText;
        [SerializeField] private Text _exitText;
        [SerializeField] private Button _chooseStoryButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _exitButton;

        private UnityAction _chooseStory;
        private UnityAction _settings;
        private UnityAction _exit;

        public void Initialize(UnityAction chooseStory, UnityAction settings, UnityAction exit)
        {
            _chooseStory = chooseStory;
            _settings = settings;
            _exit = exit;

            _chooseStoryButton.onClick.AddListener(_chooseStory);
            _settingsButton.onClick.AddListener(_settings);
            _exitButton.onClick.AddListener(_exit);

            TranslateText();
        }
        private void OnDestroy()
        {
            _chooseStoryButton.onClick.RemoveListener(_chooseStory);
            _settingsButton.onClick.RemoveListener(_settings);
            _exitButton.onClick.RemoveListener(_exit);
        }
        private void TranslateText()
        {
            _hellowText.text = Localizator.GetLocalizedValue(_localizationManager.MenuText, LocalizationTextKeys.LocalizationMenuTextKeys.HelloStory);
            _licenseText.text = Localizator.GetLocalizedValue(_localizationManager.MenuText, LocalizationTextKeys.LocalizationMenuTextKeys.LicenseText);
            _chooseStoryText.text = Localizator.GetLocalizedValue(_localizationManager.MenuText, LocalizationTextKeys.LocalizationMenuTextKeys.ChooseStory);
            _settingsText.text = Localizator.GetLocalizedValue(_localizationManager.MenuText, LocalizationTextKeys.LocalizationMenuTextKeys.Settings);
            _exitText.text = Localizator.GetLocalizedValue(_localizationManager.MenuText, LocalizationTextKeys.LocalizationMenuTextKeys.Exit);
        }
    }
}