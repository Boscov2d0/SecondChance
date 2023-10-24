using SecondChanse.Data;
using SecondChanse.Tools;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using LMTK = SecondChanse.Tools.LocalizationTextKeys.LocalizationMenuTextKeys;

namespace SecondChanse.Menu.UI.View
{
    public class MenuCanvasView : MonoBehaviour
    {
        [SerializeField] private LocalizationManager _localizationManager;
        [SerializeField] private AudioManager _audioManager;
        [SerializeField] private Text _hellowText;
        [SerializeField] private Text _licenseText;
        [SerializeField] private Text _chooseStoryText;
        [SerializeField] private Text _rulesText;
        [SerializeField] private Text _settingsText;
        [SerializeField] private Text _exitText;
        [SerializeField] private Button _chooseStoryButton;
        [SerializeField] private Button _rulesButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _exitButton;

        private UnityAction _chooseStory;
        private UnityAction _rules;
        private UnityAction _settings;
        private UnityAction _exit;

        public void Initialize(UnityAction chooseStory, UnityAction rules, UnityAction settings, UnityAction exit)
        {
            _chooseStory = chooseStory;
            _rules = rules;
            _settings = settings;
            _exit = exit;

            _chooseStoryButton.onClick.AddListener(_chooseStory);
            _rulesButton.onClick.AddListener(_rules);
            _settingsButton.onClick.AddListener(_settings);
            _exitButton.onClick.AddListener(_exit);

            TranslateText();
        }
        private void OnDestroy()
        {
            _chooseStoryButton.onClick.RemoveListener(_chooseStory);
            _rulesButton.onClick.RemoveListener(_rules);
            _settingsButton.onClick.RemoveListener(_settings);
            _exitButton.onClick.RemoveListener(_exit);
        }
        private void TranslateText()
        {
            _hellowText.text = Localizator.GetLocalizedValue(_localizationManager.MenuText, LMTK.HelloStory);
            _licenseText.text = Localizator.GetLocalizedValue(_localizationManager.MenuText, LMTK.LicenseText);
            _chooseStoryText.text = Localizator.GetLocalizedValue(_localizationManager.MenuText, LMTK.ChooseStory);
            _rulesText.text = Localizator.GetLocalizedValue(_localizationManager.MenuText, LMTK.Rules);
            _settingsText.text = Localizator.GetLocalizedValue(_localizationManager.MenuText, LMTK.Settings);
            _exitText.text = Localizator.GetLocalizedValue(_localizationManager.MenuText, LMTK.Exit);
        }
    }
}