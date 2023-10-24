using SecondChanse.Game.Tools;
using SecondChanse.Tools;
using System.Collections.Generic;
using UnityEngine;

using static SecondChanse.Game.Tools.States;

namespace SecondChanse.Game.Data
{
    [CreateAssetMenu(fileName = nameof(GameManager), menuName = "Managers/Game/GameManager")]
    public class GameManager : ScriptableObject
    {
        [field: SerializeField] public int CountOfCard { get; private set; }
        [field: SerializeField] public int FirstCardNumber { get; private set; }
        [field: SerializeField] public int CountOfCloseCard { get; private set; }
        [field: SerializeField] public int CountOfHint { get; private set; }
        [field: SerializeField] public List<ChoicesResults> RightChoices { get; private set; }

        [field: SerializeField] public string CameraPath { get; private set; }
        [field: SerializeField] public string AudioControlerPath { get; private set; }

        public SubscriptionProperty<int> CurrentCountOfCloseCard = new SubscriptionProperty<int>();
        public SubscriptionProperty<int> CurrentCountOfHint = new SubscriptionProperty<int>();
        public SubscriptionProperty<int> CountOfPoints = new SubscriptionProperty<int>();

        public SubscriptionProperty<GameState> GameState = new SubscriptionProperty<GameState>();
        
        [HideInInspector] public AnswerType CurrentAnswerType;
        [HideInInspector] public EndingState EndingState;
        [HideInInspector] public List<int> OpenCardsIndex = new List<int>();
    }
}