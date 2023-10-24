using SecondChanse.Tools;
using System.Collections.Generic;
using UnityEngine;

namespace SecondChanse.Data
{
    [CreateAssetMenu(fileName = nameof(LocalizationManager), menuName = "Managers/" + nameof(LocalizationManager))]
    public class LocalizationManager : ScriptableObject
    {
        public SubscriptionProperty<string> Language = new SubscriptionProperty<string>();

        public Dictionary<string, string> MenuText;
        public Dictionary<string, string> RulesText;
        public Dictionary<string, string> SettingsText;
        public Dictionary<string, string> StoryMapText;
        public Dictionary<string, string> GameText;

        public Dictionary<string, string> CherryBlossomFestivalText;
        public Dictionary<string, string> BloodInTheGutterText;

        public Dictionary<string, string> CurrentCardsText;

        [SerializeField] public string MenuTextsPath;
        [SerializeField] public string RulesTextsPath;
        [SerializeField] public string SettingsTextsPath;
        [SerializeField] public string StoryMapTextsPath;
        [SerializeField] public string GameTextsPath;

        [SerializeField] public string CherryBlossomFestivalTextsPath;
        [SerializeField] public string BloodInTheGutterTextsPath;
    }
}