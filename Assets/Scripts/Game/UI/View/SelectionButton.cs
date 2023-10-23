using SecondChanse.Data;
using SecondChanse.Game.Data;
using SecondChanse.Game.Tools;
using SecondChanse.Tools;
using UnityEngine;
using UnityEngine.UI;

namespace SecondChanse.Game.UI.View
{
    public class SelectionButton : MonoBehaviour
    {
        [SerializeField] private PlayerProfile _playerProfile;
        [SerializeField] private StorysManagers _storysManagers;
        [field: SerializeField] public Text Text;
        [field: SerializeField] public Button Button;
        [field: SerializeField] public AnswerType AnswerType;

        private GameManager _gameManager;

        private void Awake()
        {
            Button.onClick.AddListener(SetButtonType);

            switch (_playerProfile.Story)
            {
                case Story.CherryBlossomFestival:
                    _gameManager = _storysManagers.CherryBlossomFestivalGameManager;
                    break;
                case Story.BloodInTheGutter:
                    _gameManager = _storysManagers.BloodInTheGutterGameManager;
                    break;
            }
        }
        private void OnDestroy() => Button.onClick.RemoveListener(SetButtonType);
        private void SetButtonType() => _gameManager.CurrentAnswerType = AnswerType;
    }
}