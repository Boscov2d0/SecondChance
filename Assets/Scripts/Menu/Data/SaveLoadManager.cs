using SecondChanse.Menu.Tools;
using UnityEngine;

namespace SecondChanse.Menu.Data
{
    [CreateAssetMenu(fileName = nameof(SaveLoadManager), menuName = "Managers/Menu/SaveLoadManager")]
    public class SaveLoadManager : ScriptableObject
    {
        [field: SerializeField] public string SettingsDataPath { get; private set; }

        [field: SerializeField] public SettingsData SettingsData = new SettingsData();
    }
}