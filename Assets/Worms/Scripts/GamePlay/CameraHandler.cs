using Cinemachine;
using UnityEngine;

namespace Worms
{
    public class CameraHandler : TurnListener
    {
        [SerializeField] private TeamManager _teamManager;
        [SerializeField] private ActionChooser _actionChooser;
        
        private CinemachineFreeLook _cam;

        protected override void Awake()
        {
            base.Awake();
            _cam = GetComponent<CinemachineFreeLook>();
            _teamManager.OnPlayerSelected += FollowPlayer;
            _actionChooser.OnApplyActino += LockCursor;
        }

        private void FollowPlayer(Player player)
        {
            _cam.Follow = player.transform;
            _cam.LookAt = player.transform;
        }

        protected override void OnTurnStarted(Team team)
        {
            UnLockCursor();
        }

        protected override void OnTurnEnded() { }

        private void LockCursor()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void UnLockCursor()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}