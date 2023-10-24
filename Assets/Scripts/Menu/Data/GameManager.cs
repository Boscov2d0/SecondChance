using SecondChanse.Menu.Tools;
using SecondChanse.Tools;
using UnityEngine;

namespace SecondChanse.Menu.Data
{
    [CreateAssetMenu(fileName = nameof(GameManager), menuName = "Managers/Menu/GameManager")]
    public class GameManager : ScriptableObject
    {
        public SubscriptionProperty<MenuState> State = new SubscriptionProperty<MenuState>();

        [field: SerializeField] public string CameraPath { get; private set; }
        [field: SerializeField] public string AudioControlerPath { get; private set; }
    }
}