using UnityEngine;
using UnityEngine.InputSystem;

namespace Worms
{
    public class CameraController : MonoBehaviour
    {
        public Transform target;
        public bool invertedX;
        public bool invertedY;
        public float sensitivity;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _distance;
        
        [SerializeField] private LayerMask _terrainLayer; 
        [SerializeField] private PlayerInput _input;
    
        private InputAction _action;
        private Vector2 _rotationVector;
        private Vector3 _targetPoint;
        private Vector3 _defaultPos;
        private Quaternion _defaultRotation;
        private Vector3 _velocity = Vector3.zero;

        private void Start()
        {
            _defaultPos = transform.position;
            _defaultRotation = transform.rotation;
            _action = _input.actions["Look"];
        }

        private void LateUpdate()
        {
            if (target == null)
            {
                transform.position = _defaultPos;
                transform.rotation = _defaultRotation;
                return;
            }
            SetPosition();
        }

        private void SetPosition()
        {
            var inputVec = _action.ReadValue<Vector2>();
            _rotationVector += inputVec * (sensitivity * Time.deltaTime);
            var rotation = Quaternion.Euler(_rotationVector.y * (invertedY ? -1 : 1),
                _rotationVector.x * (invertedX ? -1 : 1), 0);

            _targetPoint = RotateAroundPoint(target.position + Vector3.back * _distance, target.position,
                rotation);

            var newPoint = Vector3.SmoothDamp(transform.position, _targetPoint, ref _velocity, _moveSpeed);
            
            transform.position = GetPosAfterCollision(_targetPoint);
            transform.LookAt(target);
        }

        private Vector3 GetPosAfterCollision(Vector3 point)
        {
            var ray = new Ray(target.position, point - target.position);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, _distance, _terrainLayer))
                return hitInfo.point;
            else
                return point;
        }
        
        private Vector3 RotateAroundPoint(Vector3 point, Vector3 anchor, Quaternion rotation)
        {
            var newPos = point - anchor;
            newPos = rotation * newPos;
            newPos += anchor;
            return newPos;
        }
    }
}