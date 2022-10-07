using UnityEngine;

namespace Worms
{
    public class CameraHandler : TurnListener
    {
        [SerializeField] private TeamManager _teamManager;
        [SerializeField] private ActionChooser _actionChooser;
        
        private CameraController _cam;
        private Transform _target;

        protected override void Awake()
        {
            base.Awake();
            _cam = GetComponent<CameraController>();
            _teamManager.OnPlayerSelected += FollowPlayer;
            _actionChooser.OnApplyAction += LockCursor;
            PauseManager.OnPause += OnPause;
        }

        private void OnPause(bool paused)
        {
            if (paused) 
                UnLockCursor();
            else
                LockCursor();
        }

        private void FollowPlayer(Player player)
        {
            _target = player.transform;
            
            if(!Cursor.visible)
                _cam.target = _target;
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

            _cam.target = _target;
        }

        private void UnLockCursor()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            _cam.target = null;
        }

        private void OnDisable()
        {
            _actionChooser.OnApplyAction -= LockCursor;
            PauseManager.OnPause -= OnPause;
        }
    }
}