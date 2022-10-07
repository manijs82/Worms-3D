using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Worms
{
    public class SettingsApplier : MonoBehaviour
    {
        [SerializeField] private PostProcessVolume _postProcessVolume;
        [SerializeField] private CameraController _cameraController;

        private void OnEnable()
        {
            var postIsOn = PlayerPrefs.GetInt("Post", 1) == 1;
            var invertX = PlayerPrefs.GetInt("InvertX", 0) == 1;
            var invertY = PlayerPrefs.GetInt("InvertY", 1) == 1;
            var camSens = PlayerPrefs.GetFloat("CamSens", 1);

            _postProcessVolume.isGlobal = postIsOn;
            _cameraController.invertedX = invertX;
            _cameraController.invertedY = invertY;
            _cameraController.sensitivity = camSens * 10;
        }
    }
}