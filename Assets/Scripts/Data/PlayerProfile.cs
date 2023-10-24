using SecondChanse.Tools;
using UnityEngine;

namespace SecondChanse.Data
{
    [CreateAssetMenu(fileName = nameof(PlayerProfile), menuName = "Managers/" + nameof(PlayerProfile))]
    public class PlayerProfile : ScriptableObject
    {
        [HideInInspector] public Story Story;
    }
}