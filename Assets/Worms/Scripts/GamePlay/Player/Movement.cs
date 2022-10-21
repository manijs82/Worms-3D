using UnityEngine;
using UnityEngine.InputSystem;

namespace Worms
{
    [RequireComponent(typeof(CharacterController))]
    public class Movement : Ability
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpAmount;
        [SerializeField] private Vector3 gravity;
        [SerializeField] private Animator animator;
        
        private CharacterController _controller;
        private Transform _camera;
        private Vector3 _inputDir;
        private Vector3 _moveDir;
        private Vector3 _moveVector;

        public Vector3 MoveDir => _moveDir;

        public override void Initialize(Player owner)
        {
            base.Initialize(owner);
            _camera = owner.cam;
            _controller = GetComponent<CharacterController>();
            owner.input.actions["Move"].performed += SetMoveVector;
            owner.input.actions["Move"].canceled += SetMoveVector;
            owner.input.actions["Jump"].performed += Jump;
        }

        private void Update()
        {
            if(!_owner.IsActive)
                _controller.Move(gravity * Time.deltaTime);
        }

        protected override void DoAbility() => 
            Move();

        private void SetMoveVector(InputAction.CallbackContext ctx)
        {
            if(!_owner.IsActive) return;

            var readValue = ctx.ReadValue<Vector2>();
            _inputDir = new Vector3(readValue.x, 0, readValue.y).normalized;
        }

        private void Jump(InputAction.CallbackContext obj)
        {
            if(!_owner.IsActive) return;
            
            if (_controller.isGrounded)
                _moveVector.y = _jumpAmount;
        }

        private void Move()
        {
            SetMoveDirection();
            var moveAmount = _moveDir.magnitude * _speed;
            _moveVector = new Vector3(_moveDir.x * moveAmount, _moveVector.y, _moveDir.z * moveAmount);
            _moveVector += gravity * Time.deltaTime;      

            _controller.Move(_moveVector * Time.deltaTime);
            animator.SetBool("IsMoving", _moveDir.magnitude > .01f);
        }

        private void SetMoveDirection()
        {
            var camForward = new Vector3(_camera.forward.x, 0, _camera.forward.z);
            var offsetAngle = Vector3.SignedAngle(Vector3.forward, camForward, Vector3.up);
            _moveDir = Quaternion.AngleAxis(offsetAngle, Vector3.up) * _inputDir;
        }

        private void OnDisable()
        {
            if(_owner.input == null) return;
            
            _owner.input.actions["Move"].performed -= SetMoveVector;
            _owner.input.actions["Move"].canceled -= SetMoveVector;
            _owner.input.actions["Jump"].performed -= Jump;
        }
    }
}