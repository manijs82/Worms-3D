using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Worms
{
    public class PauseManager : MassageSender
    {
        public static event Action<bool> OnPause;
        
        [SerializeField] private PlayerInput _input;

        private bool _paused;
        
        private void Start()
        {
            _input.actions["Pause"].performed += TogglePause;
        }

        private void TogglePause(InputAction.CallbackContext ctx)
        {
            PauseGame();
        }

        public void PauseGame()
        {
            _paused = !_paused;
            OnPause?.Invoke(_paused);
            SendMassage();
        }
    }
}