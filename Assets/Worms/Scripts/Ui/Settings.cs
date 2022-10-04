using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Worms
{
    public class Settings : MonoBehaviour
    {
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private Slider _masterVolumeSlider;
        [SerializeField] private Toggle _invertYToggle;
        [SerializeField] private Toggle _invertXToggle;
        [SerializeField] private Toggle _post;
        
        private void Start()
        {
            _post.isOn = PlayerPrefs.GetInt("Post", 1) == 1;
            _invertXToggle.isOn = PlayerPrefs.GetInt("InvertX", 0) == 1;
            _invertYToggle.isOn = PlayerPrefs.GetInt("InvertY", 1) == 1;
            _masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0);
            _audioMixer.SetFloat("MasterVolume", _masterVolumeSlider.value);
        }

        public void TogglePost()
        {
            var isOn = PlayerPrefs.GetInt("Post", 1) == 1;
            PlayerPrefs.SetInt("Post", isOn ? 0 : 1);
        }
        
        public void ToggleInvertX()
        {
            var isOn = PlayerPrefs.GetInt("InvertX", 0) == 1;
            PlayerPrefs.SetInt("InvertX", isOn ? 0 : 1);
        }
        
        public void ToggleInvertY()
        {
            var isOn = PlayerPrefs.GetInt("InvertY", 1) == 1;
            PlayerPrefs.SetInt("InvertY", isOn ? 0 : 1);
        }
        
        public void SetMasterVolume(float value)
        {
            PlayerPrefs.SetFloat("MasterVolume", value);
            _audioMixer.SetFloat("MasterVolume", _masterVolumeSlider.value);
        }
    }
}
