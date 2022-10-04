using UnityEngine;

namespace Worms
{
    public abstract class TurnListener : MonoBehaviour
    {
        private TurnManager _turnManager;

        protected virtual void Awake()
        {
            _turnManager = FindObjectOfType<TurnManager>();
            _turnManager.OnTurnStarted += OnTurnStarted;
            _turnManager.OnTurnEnded += OnTurnEnded;
        }

        protected abstract void OnTurnStarted(Team team);

        protected abstract void OnTurnEnded();
    }
}