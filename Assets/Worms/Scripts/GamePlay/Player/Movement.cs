using UnityEngine;
using UnityEngine.InputSystem;

namespace Worms
{
    [RequireComponent(typeof(CharacterController))]
    public class Movement : Ability
    {
        [SerializeField] private float _speed;
        [SerializeField] private Vector3 gravity;
        
        private CharacterController _controller;
        private Transform _camera;
        private Vector3 _inputDir;
        private float _moveAmount;
        
        public override void Initialize(Player owner)
        {
            base.Initialize(owner);
            _camera = owner.cam;
            _controller = GetComponent<CharacterController>();
            owner.input.actions["Move"].performed += SetMoveVector;
            owner.input.actions["Move"].canceled += SetMoveVector;
        }

        protected override void PerformAction()
        {
            Move();
        }

        private void SetMoveVector(InputAction.CallbackContext ctx)
        {
            var readValue = ctx.ReadValue<Vector2>();
            _inputDir = new Vector3(readValue.x, 0, readValue.y);
            _moveAmount = readValue.magnitude * _speed * Time.deltaTime;
        }

        private void Move()
        {
            var camForward = new Vector3(_camera.forward.x, 0, _camera.forward.z);
            var offsetAngle = Vector3.SignedAngle(Vector3.forward, camForward, Vector3.up);
            var moveDir = Quaternion.AngleAxis(offsetAngle, Vector3.up) * _inputDir;
            
            _controller.Move(moveDir * _moveAmount + gravity);
        }

        private void OnDisable()
        {
            _owner.input.actions["Move"].performed -= SetMoveVector;
            _owner.input.actions["Move"].canceled -= SetMoveVector;
        }
    }
}