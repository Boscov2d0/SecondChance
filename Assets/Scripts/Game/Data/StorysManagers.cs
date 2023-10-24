using UnityEngine;

namespace SecondChanse.Game.Data
{
    [CreateAssetMenu(fileName = nameof(StorysManagers), menuName = "Managers/Game/StorysManagers")]
    public class StorysManagers : ScriptableObject
    {
        [field: SerializeField] public GameManager CherryBlossomFestivalGameManager { get; private set; }
        [field: SerializeField] public GameManager BloodInTheGutterGameManager { get; private set; }
        [field: SerializeField] public CardsSpriteManager CherryBlossomFestivalCardsSpriteManager { get; private set; }
    }
}