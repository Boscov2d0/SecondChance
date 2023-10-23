using UnityEngine;
using UnityEngine.Audio;

namespace SecondChanse.Data
{
    [CreateAssetMenu(fileName = nameof(AudioManager), menuName = "Managers/" + nameof(AudioManager))]
    public class AudioManager : ScriptableObject
    {
        [field: SerializeField] public AudioMixer AudioMixer { get; private set; }
        [field: SerializeField] public AudioClip SimpleClickSound { get; private set; }
        [field: SerializeField] public AudioClip ApplyClickSound { get; private set; }
        [HideInInspector] public AudioSource SimpleClickAudioSource;
        [HideInInspector] public AudioSource ApplyClickAudioSource;
        [HideInInspector] public float SoundsValue;
        [HideInInspector] public float MusicValue;
    }
}