using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Worms
{
    public class CameraController : MonoBehaviour
    {
        public Transform target;
        [SerializeField] private float _sensetivity;
        [SerializeField] private PlayerInput _input;

        private InputAction _action;
        private Vector2 _rotation;

        private void Start()
        {
            _action = _input.actions["Look"];
        }

        private void Update()
        {
            GetInput();
            
        }

        private void GetInput()
        {
            var inputVec = _action.ReadValue<Vector2>();
            _rotation = inputVec * (_sensetivity * Time.deltaTime);
        }
        
        /*private Vector3 RotateAroundPoint(this Vector3 point, Vector3 anchor, Quaternion rotation)
        {
            var newPos = point - anchor;
            newPos = rotation * newPos;
            newPos += anchor;
            return newPos;
        }*/
    }
}