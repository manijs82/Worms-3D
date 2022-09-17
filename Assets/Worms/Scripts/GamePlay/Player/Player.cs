using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Worms
{
    public class Player : MonoBehaviour
    {
        public bool isActive;
        [SerializeField] private List<Ability> _abilities;
        
        [HideInInspector] public PlayerInput input;
        [HideInInspector] public Transform cam;

        private void Start()
        {
            cam = FindObjectOfType<Camera>().transform;
            input = FindObjectOfType<PlayerInput>();
            foreach (var ability in _abilities) 
                ability.Initialize(this);
        }

        private void Update()
        {
            if(!isActive) return;
            foreach (var ability in _abilities) 
                ability.Use();
        }
    }
}