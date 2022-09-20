﻿using UnityEngine;

namespace Worms
{
    public abstract class TurnListener : MonoBehaviour
    {
        [SerializeField] private TurnManager turnManager;

        private void Awake()
        {
            turnManager.OnTurnStarted += OnTurnStarted;
            turnManager.OnTurnEnded += OnTurnEnded;
        }

        protected abstract void OnTurnStarted(Team team);

        protected abstract void OnTurnEnded();
    }
}