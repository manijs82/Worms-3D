using UnityEngine;

namespace Worms
{
    public class SoundManager : Singleton<SoundManager>
    {
        [SerializeField] private AudioSource _audioSource;

        public void PlaySound(AudioClip audioClip)
        {
            _audioSource.clip = audioClip;
            _audioSource.Play();
        }

    }
}