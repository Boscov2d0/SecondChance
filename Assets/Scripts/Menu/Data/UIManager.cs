using UnityEngine;

namespace SecondChanse.Menu.Data
{
    [CreateAssetMenu(fileName = nameof(UIManager), menuName = "Managers/Menu/UIManager")]
    public class UIManager : ScriptableObject
    {
        [field: SerializeField] public string UIObjectsPath;
        [field: SerializeField] public string MenuCanvasPath;
        [field: SerializeField] public string StoryMapCanvasPath;
        [field: SerializeField] public string RulesCanvasPath;
        [field: SerializeField] public string SetingsCanvasPath;
    }
}