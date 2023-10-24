using System.Collections.Generic;
using UnityEngine;

namespace SecondChanse.Game.Data
{
    [CreateAssetMenu(fileName = nameof(ChoicesResults), menuName = "Managers/Game/ChoicesResults")]
    public class ChoicesResults : ScriptableObject
    {
        [field: SerializeField] public List<string> Choice;
        [field: SerializeField] public List<string> Result;
    }
}