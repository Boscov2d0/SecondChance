using SecondChanse.Data;
using SecondChanse.Menu.Data;
using SecondChanse.Menu.Tools;
using SecondChanse.Tools;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SecondChanse.Core
{
    public class LocalizationController : ObjectsDisposer
    {
        private readonly SaveLoadManager _saveLoadManager;
        private readonly LocalizationManager _localizationManager;

        public LocalizationController(SaveLoadManager saveLoadManager, LocalizationManager localizationManager)
        {
            _saveLoadManager = saveLoadManager;
            _localizationManager = localizationManager;

            _localizationManager.Language.SubscribeOnChange(LoadMenuText);
            _localizationManager.Language.SubscribeOnChange(LoadStoryMapText);
            _localizationManager.Language.SubscribeOnChange(LoadSettingsText);
            _localizationManager.Language.SubscribeOnChange(LoadGameText);
            _localizationManager.Language.SubscribeOnChange(LoadRulesText);
            _localizationManager.Language.SubscribeOnChange(LoadCherryBlossomFestivalText);
            _localizationManager.Language.SubscribeOnChange(LoadBloodInTheGutterText);

            SetLanguage();
        }
        protected override void OnDispose()
        {
            _localizationManager.Language.UnSubscribeOnChange(LoadMenuText);
            _localizationManager.Language.UnSubscribeOnChange(LoadStoryMapText);
            _localizationManager.Language.UnSubscribeOnChange(LoadSettingsText);
            _localizationManager.Language.UnSubscribeOnChange(LoadGameText);
            _localizationManager.Language.UnSubscribeOnChange(LoadRulesText);
            _localizationManager.Language.UnSubscribeOnChange(LoadCherryBlossomFestivalText);
            _localizationManager.Language.UnSubscribeOnChange(LoadBloodInTheGutterText);
        }
        private void SetLanguage()
        {
            if (!string.IsNullOrEmpty(_localizationManager.Language.Value))
            {
                LoadText();
                return;
            }

            if (Application.systemLanguage == SystemLanguage.Russian ||
                Application.systemLanguage == SystemLanguage.Ukrainian ||
                Application.systemLanguage == SystemLanguage.Belarusian)
                _localizationManager.Language.Value = Keys.LanguageKeys.ru_RU.ToString();
            else if (Application.systemLanguage == SystemLanguage.Chinese ||
                     Application.systemLanguage == SystemLanguage.ChineseSimplified ||
                     Application.systemLanguage == SystemLanguage.ChineseTraditional)
                _localizationManager.Language.Value = Keys.LanguageKeys.zh_ZH.ToString();
            else
                _localizationManager.Language.Value = Keys.LanguageKeys.en_US.ToString();

            Saver.SaveLanguageSettingsData(_saveLoadManager, _localizationManager);
        }
        private void LoadText() 
        {
            LoadMenuText();
            LoadStoryMapText();
            LoadSettingsText();
            LoadGameText();
            LoadRulesText();
            LoadCherryBlossomFestivalText();
            LoadBloodInTheGutterText();
        }
        private void LoadMenuText()
        {
            _localizationManager.MenuText = new Dictionary<string, string>();
            LoadLocalizedText(_localizationManager.MenuText, _localizationManager.MenuTextsPath);
        }
        private void LoadStoryMapText()
        {
            _localizationManager.StoryMapText = new Dictionary<string, string>();
            LoadLocalizedText(_localizationManager.StoryMapText, _localizationManager.StoryMapTextsPath);
        }
        private void LoadSettingsText()
        {
            _localizationManager.SettingsText = new Dictionary<string, string>();
            LoadLocalizedText(_localizationManager.SettingsText, _localizationManager.SettingsTextsPath);
        }
        private void LoadGameText()
        {
            _localizationManager.GameText = new Dictionary<string, string>();
            LoadLocalizedText(_localizationManager.GameText, _localizationManager.GameTextsPath);
        }
        private void LoadRulesText()
        {
            _localizationManager.RulesText = new Dictionary<string, string>();
            LoadLocalizedText(_localizationManager.RulesText, _localizationManager.RulesTextsPath);
        }
        public void LoadCherryBlossomFestivalText()
        {
            _localizationManager.CherryBlossomFestivalText = new Dictionary<string, string>();
            LoadLocalizedText(_localizationManager.CherryBlossomFestivalText, _localizationManager.CherryBlossomFestivalTextsPath);
        }
        public void LoadBloodInTheGutterText()
        {
            _localizationManager.BloodInTheGutterText = new Dictionary<string, string>();
            LoadLocalizedText(_localizationManager.BloodInTheGutterText, _localizationManager.BloodInTheGutterTextsPath);
        }
        public void LoadLocalizedText(Dictionary<string, string> text, string path)
        {
            string dataAsJson;
            string fullPath = Application.streamingAssetsPath + path + _localizationManager.Language.Value + ".json";
            
            dataAsJson = File.ReadAllText(fullPath);

            LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

            for (int i = 0; i < loadedData.items.Length; i++)
            {
                text.Add(loadedData.items[i].key, loadedData.items[i].value);
            }
        }
    }
}