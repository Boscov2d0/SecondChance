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
        [SerializeField] private Image _image;
        [field: SerializeField] public Text Text;
        [field: SerializeField] public Button Button;
        [field: SerializeField] public AnswerType AnswerType;

        private GameManager _gameManager;
        private int _answersPointResult;
        public int AnswersPointResult { get { return _answersPointResult; } private set { } }

        public void Initialize(int answersPointResult)
        {
            _answersPointResult = answersPointResult;

            Button.onClick.AddListener(SetButtonColor);
            Button.onClick.AddListener(SetButtonType);

            switch (_playerProfile.Story)
            {
                case Story.CherryBlossomFestival:
                    _gameManager = _storysManagers.CherryBlossomFestivalGameManager;
                    break;
            }
        }
        private void OnDestroy()
        {
            Button.onClick.AddListener(SetButtonColor);
            Button.onClick.RemoveListener(SetButtonType);
        }
        public void SetButtonColor()
        {
            Color tempColor = _image.color;
            tempColor.a = 75;
            _image.color = tempColor;
        }
        private void SetButtonType() => _gameManager.CurrentAnswerType = AnswerType;
    }
}