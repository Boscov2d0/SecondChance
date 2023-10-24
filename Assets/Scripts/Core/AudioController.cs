using SecondChanse.Data;
using SecondChanse.Tools;
using UnityEngine;

namespace SecondChanse.Core
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private PlayerProfile _playerProfile;
        [SerializeField] private AudioManager _audioManager;
        [SerializeField] private AudioSource _simpleClickSound;
        [SerializeField] private AudioSource _applyClickSound;
        [SerializeField] private AudioSource _music;

        private void Awake()
        {
            _simpleClickSound.clip = _audioManager.SimpleClickSound;
            _applyClickSound.clip = _audioManager.ApplyClickSound;
            _audioManager.SimpleClickAudioSource = _simpleClickSound;
            _audioManager.ApplyClickAudioSource = _applyClickSound;

            switch (_playerProfile.Story)
            {
                case Story.CherryBlossomFestival:
                    _music.clip = _audioManager.CherryBlossomFestivalMusic;
                    _audioManager.CherryBlossomFestivalAudioSource = _music;
                    break;
                case Story.BloodInTheGutter:
                    _music.clip = _audioManager.BloodInTheGutterMusic;
                    _audioManager.BloodInTheGutterAudioSource = _music;
                    break;
            }

            _music.Play();
        }
    }
}
