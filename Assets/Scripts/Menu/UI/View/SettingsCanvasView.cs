using SecondChanse.Data;
using SecondChanse.Menu.Data;
using SecondChanse.Tools;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SecondChanse.Menu.UI.View
{
    public class SettingsCanvasView : MonoBehaviour
    {
        [SerializeField] private LocalizationManager _localizationManager;
        [SerializeField] private VideoManager _videoManager;
        [SerializeField] private AudioManager _audioManager;
        [SerializeField] private Text _languageText;
        [SerializeField] private Text _screenResolutionText;
        [SerializeField] private Text _fullscreenText;
        [SerializeField] private Text _soundText;
        [SerializeField] private Text _musicText;
        [SerializeField] private Text _backText;
        [SerializeField] private Button _russianLanguageButton;
        [SerializeField] private Button _englishLanguageButton;
        [SerializeField] private Button _chineeseLanguageButton;
        [SerializeField] private Dropdown _screenResolutionDropdown;
        [SerializeField] private Button _fullscreenOnButton;
        [SerializeField] private Button _fullscreenOffButton;
        [SerializeField] private Slider _soundSlider;
        [SerializeField] private Slider _musicSlider;
        [SerializeField] private Button _backButton;

        private UnityAction _russianLanguage;
        private UnityAction _englishLanguage;
        private UnityAction _chineeseLanguage;
        private UnityAction<int> _setScreenResolution;
        private UnityAction _fullScreenOn;
        private UnityAction _fullScreenOff;
        private UnityAction<float> _onSoundValueChange;
        private UnityAction<float> _onMusicValueChange;
        private UnityAction _back;

        public Dropdown ScreenResolutionDropdown => _screenResolutionDropdown;

        public void Initialize(UnityAction russianLanguage, UnityAction englishLanguage, UnityAction chineeseLanguage,
                               UnityAction<int> setScreenResolution, UnityAction fullScreenOn, UnityAction fullScreenOff,
                               UnityAction<float> onSoundValueChange, UnityAction<float> onMusicValueChange,
                               UnityAction back)
        {
            _russianLanguage = russianLanguage;
            _englishLanguage = englishLanguage;
            _chineeseLanguage = chineeseLanguage;
            _setScreenResolution = setScreenResolution;
            _fullScreenOn = fullScreenOn;
            _fullScreenOff = fullScreenOff;
            _onSoundValueChange = onSoundValueChange;
            _onMusicValueChange = onMusicValueChange;
            _back = back;

            _russianLanguageButton.onClick.AddListener(_russianLanguage);
            _englishLanguageButton.onClick.AddListener(_englishLanguage);
            _chineeseLanguageButton.onClick.AddListener(_chineeseLanguage);
            _fullscreenOnButton.onClick.AddListener(_fullScreenOn);
            _fullscreenOffButton.onClick.AddListener(_fullScreenOff);
            _fullscreenOnButton.onClick.AddListener(SetFullscreenButton);
            _fullscreenOffButton.onClick.AddListener(SetFullscreenButton);
            _backButton.onClick.AddListener(_back);

            SetDropdownText();
            _screenResolutionDropdown.onValueChanged.AddListener(_setScreenResolution);
            SetFullscreenButton();
            SetAudioSliders();
            _soundSlider.onValueChanged.AddListener(_onSoundValueChange);
            _musicSlider.onValueChanged.AddListener(_onMusicValueChange);

            _localizationManager.Language.SubscribeOnChange(TranslateText);

            TranslateText();
        }
        private void OnDestroy()
        {
            _russianLanguageButton.onClick.RemoveListener(_russianLanguage);
            _englishLanguageButton.onClick.RemoveListener(_englishLanguage);
            _chineeseLanguageButton.onClick.RemoveListener(_chineeseLanguage);
            _fullscreenOnButton.onClick.RemoveListener(_fullScreenOn);
            _fullscreenOffButton.onClick.RemoveListener(_fullScreenOff);
            _fullscreenOnButton.onClick.RemoveListener(SetFullscreenButton);
            _fullscreenOffButton.onClick.RemoveListener(SetFullscreenButton);
            _backButton.onClick.RemoveListener(_back);

            _screenResolutionDropdown.onValueChanged.RemoveAllListeners();

            _soundSlider.onValueChanged.RemoveListener(_onSoundValueChange);
            _musicSlider.onValueChanged.RemoveListener(_onMusicValueChange);

            _localizationManager.Language.UnSubscribeOnChange(TranslateText);
        }
        private void SetDropdownText()
        {
            Dropdown.OptionData data;

            for (int i = 0; i < Screen.resolutions.Length; i++)
            {
                data = new Dropdown.OptionData() { text = Screen.resolutions[i].ToString() };
                _screenResolutionDropdown.options.Add(data);
                if (data.text == Screen.currentResolution.ToString())
                    _screenResolutionDropdown.value = i;
            }
        }
        private void SetFullscreenButton()
        {
            if (_videoManager.Fullscreen)
            {
                _fullscreenOnButton.interactable = false;
                _fullscreenOffButton.interactable = true;
            }
            else
            {
                _fullscreenOnButton.interactable = true;
                _fullscreenOffButton.interactable = false;
            }
        }
        private void SetAudioSliders()
        {
            _soundSlider.value = _audioManager.SoundsValue;
            _musicSlider.value = _audioManager.MusicValue;
        }
        private void TranslateText()
        {
            _languageText.text = Localizator.GetLocalizedValue(_localizationManager.SettingsText, LocalizationTextKeys.LocalizationSettingsTextKeys.Language);
            _screenResolutionText.text = Localizator.GetLocalizedValue(_localizationManager.SettingsText, LocalizationTextKeys.LocalizationSettingsTextKeys.Resolution);
            _fullscreenText.text = Localizator.GetLocalizedValue(_localizationManager.SettingsText, LocalizationTextKeys.LocalizationSettingsTextKeys.Fullscreen);
            _soundText.text = Localizator.GetLocalizedValue(_localizationManager.SettingsText, LocalizationTextKeys.LocalizationSettingsTextKeys.Sounds);
            _musicText.text = Localizator.GetLocalizedValue(_localizationManager.SettingsText, LocalizationTextKeys.LocalizationSettingsTextKeys.Musics);
            _backText.text = Localizator.GetLocalizedValue(_localizationManager.SettingsText, LocalizationTextKeys.LocalizationSettingsTextKeys.Back);
        }
    }
}