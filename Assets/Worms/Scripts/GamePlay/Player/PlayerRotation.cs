using UnityEngine;

namespace Worms
{
    public class PlayerRotation : Ability
    {
        [SerializeField] private float _rotationSpeed;
        
        private Movement _movement;
        private Quaternion _currentRotation;
        private Quaternion _newRotation;
        
        public override void Initialize(Player owner)
        {
            base.Initialize(owner);
            _movement = GetComponent<Movement>();
        }

        protected override void DoAbility()
        {
            SetNewRotation();
            
            _currentRotation = Quaternion.RotateTowards(_currentRotation, _newRotation, _rotationSpeed);
            _owner.model.transform.rotation = _currentRotation;
        }
        
        private void SetNewRotation()
        {
            if (Input.GetMouseButton(1))
            {
                var camForward = new Vector3(_owner.cam.forward.x, 0, _owner.cam.forward.z);
                _newRotation = Quaternion.LookRotation(camForward);
                return;
            }
            if(_movement.MoveDir != Vector3.zero) 
                _newRotation = Quaternion.LookRotation(_movement.MoveDir);
        }
    }
}