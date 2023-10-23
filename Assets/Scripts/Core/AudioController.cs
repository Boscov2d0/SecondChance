using SecondChanse.Data;
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

            _music.Play();
        }
    }
}
