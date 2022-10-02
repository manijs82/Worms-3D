using UnityEngine;
using UnityEngine.InputSystem;

namespace Worms
{
    public class PauseManager : MassageSender
    {
        [SerializeField] private PlayerInput _input;

        private bool _paused;
        
        private void Start()
        {
            _input.actions["Pause"].performed += TogglePause;
        }

        private void TogglePause(InputAction.CallbackContext ctx)
        {
            SendMassage();
        }
    }
}