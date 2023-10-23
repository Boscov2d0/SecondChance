using SecondChanse.Game.Data;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SecondChanse.Game.UI.View
{
    public class PlayBoardCanvasView : MonoBehaviour
    {
        [SerializeField] private Text _storyCartLeftText;
        [SerializeField] private Text _hintCartLeftText;
        [SerializeField] private Text _storyCartLeftValue;
        [SerializeField] private Text _hintCartLeftValue;
        [SerializeField] private Button _playMusicButton;
        [SerializeField] private Button _muteMusicButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private List<Transform> _upperCardPlaces;
        [SerializeField] private List<Transform> _downardPlaces;

        private GameManager _gameManager;

        public List<Transform> UpperCardPlaces => _upperCardPlaces;
        public List<Transform> DownardPlaces => _downardPlaces;

        private UnityAction _playMusic;
        private UnityAction _muteMusic;
        private UnityAction _exit;

        public void Initialize(GameManager gameManager, UnityAction playMusic, UnityAction muteMusic, UnityAction exit)
        {
            _gameManager = gameManager;
            _playMusic = playMusic;
            _muteMusic = muteMusic;
            _exit = exit;

            _playMusicButton.onClick.AddListener(_playMusic);
            _muteMusicButton.onClick.AddListener(_muteMusic);
            _exitButton.onClick.AddListener(_exit);

            _gameManager.CurrentCountOfCloseCard.SubscribeOnChange(OnStoryCartValueChange);
            _gameManager.CurrentCountOfHint.SubscribeOnChange(OnHintCartValueChange);
        }
        private void OnDestroy()
        {
            _gameManager.CurrentCountOfCloseCard.UnSubscribeOnChange(OnStoryCartValueChange);
            _gameManager.CurrentCountOfHint.UnSubscribeOnChange(OnHintCartValueChange);

            _playMusicButton.onClick.RemoveListener(_playMusic);
            _muteMusicButton.onClick.RemoveListener(_muteMusic);
            _exitButton.onClick.RemoveListener(_exit);
        }
        private void OnStoryCartValueChange() 
        {
            _storyCartLeftValue.text = _gameManager.CurrentCountOfCloseCard.Value.ToString();
        }
        private void OnHintCartValueChange() 
        {
            _hintCartLeftValue.text = _gameManager.CurrentCountOfHint.Value.ToString();
        }
    }
}