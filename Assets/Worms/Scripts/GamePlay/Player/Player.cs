using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Worms
{
    public class Player : MonoBehaviour
    {
        public GameObject model;
        [SerializeField] private List<Ability> _abilities;

        [HideInInspector] public PlayerInput input;
        [HideInInspector] public Transform cam;
        private bool _isActive;

        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                OnSetActive();
            }
        }

        private void Awake()
        {
            cam = FindObjectOfType<Camera>().transform;
            input = FindObjectOfType<PlayerInput>();
            foreach (var ability in _abilities)
                ability.Initialize(this);
        }

        private void OnSetActive()
        {
            gameObject.layer = LayerMask.NameToLayer(_isActive ? "ActivePlayer" : "InActivePlayer");
        }

        private void Update()
        {
            if (!IsActive) return;
            foreach (var ability in _abilities)
                ability.Use();
        }

        public void SetColor(Color color)
        {
            model.GetComponent<Renderer>().material.color = color;
        }

        public void StartTurn()
        {
            foreach (var ability in _abilities)
                ability.OnStartTurn();
        }

        public void EndTurn()
        {
            foreach (var ability in _abilities)
                ability.OnEndTurn();

            IsActive = false;
        }

        public T GetAbility<T>() where T : Ability
        {
            return GetComponent<T>();
        }
    }
}