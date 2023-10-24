using UnityEngine;

namespace SecondChanse.Game.Data
{
    [CreateAssetMenu(fileName = nameof(UIManager), menuName = "Managers/Game/UIManager")]
    public class UIManager : ScriptableObject
    {
        [field: SerializeField] public string UIObjectsPath { get; private set; }
        [field: SerializeField] public string PlayBoatdCanvasPath { get; private set; }
        [field: SerializeField] public string CloseCardPath { get; private set; }
        [field: SerializeField] public string OpenCardPath { get; private set; }
        [field: SerializeField] public string StoryCardCanvasPath { get; private set; }
        [field: SerializeField] public string EndinsCanvasPath { get; private set; }
        [field: SerializeField] public string FullStoryCanvasPath { get; private set; }
        [field: SerializeField] public string ImportantDecisionsCanvasPath { get; private set; }
    }
}