using Cinemachine;
using UnityEngine;

namespace Worms
{
    public class CameraHandler : MonoBehaviour
    {
        [SerializeField] private TeamManager teamManager;
        
        private CinemachineFreeLook cam;

        private void Awake()
        {
            cam = GetComponent<CinemachineFreeLook>();
            teamManager.OnPlayerSelected += FollowPlayer;
        }

        private void FollowPlayer(Player player)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            
            cam.Follow = player.transform;
            cam.LookAt = player.transform;
        }
    }
}