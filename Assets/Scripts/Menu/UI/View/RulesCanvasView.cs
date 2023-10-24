using SecondChanse.Data;
using SecondChanse.Menu.Data;
using SecondChanse.Tools;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SecondChanse.Menu.UI.View
{
    public class RulesCanvasView : MonoBehaviour
    {
        [SerializeField] private LocalizationManager _localizationManager;
        [SerializeField] private Text _nextText;
        [SerializeField] private Text _backText;
        [SerializeField] private Text _menuText;        
        [SerializeField] private List<Text> _pagesText;
        [SerializeField] private List<Transform> _pages;
        [SerializeField] private Button _nextPageButton;
        [SerializeField] private Button _prevPageButton;
        [SerializeField] private Button _menuButton;

        private UnityAction _nextPage;
        private UnityAction _backPage;
        private UnityAction _menu;

        public List<Transform> Pages => _pages;
        public Button NextPageButton => _nextPageButton;
        public Button PrevPageButton => _prevPageButton;

        public void Initialize(UnityAction nextPage, UnityAction backPage, UnityAction menu)
        {
            _nextPage = nextPage;
            _backPage = backPage;
            _menu = menu;

            _nextPageButton.onClick.AddListener(_nextPage);
            _prevPageButton.onClick.AddListener(_backPage);
            _menuButton.onClick.AddListener(_menu);

            TranslateText();
        }
        private void OnDestroy()
        {
            _nextPageButton.onClick.RemoveListener(_nextPage);
            _prevPageButton.onClick.RemoveListener(_backPage);
            _menuButton.onClick.RemoveListener(_menu);
        }
        private void TranslateText()
        {
            _nextText.text = Localizator.GetLocalizedValue(_localizationManager.RulesText, LocalizationTextKeys.LocalizationRulesTextKeys.Next);
            _backText.text = Localizator.GetLocalizedValue(_localizationManager.RulesText, LocalizationTextKeys.LocalizationRulesTextKeys.Prev);
            _menuText.text = Localizator.GetLocalizedValue(_localizationManager.RulesText, LocalizationTextKeys.LocalizationRulesTextKeys.Back);

            for (int i = 0; i < _pagesText.Count; i++) 
            {
                _pagesText[i].text = Localizator.GetLocalizedValue(_localizationManager.RulesText, LocalizationTextKeys.LocalizationRulesTextKeys.Page + ((i+1).ToString()));
            }
        }
    }
}