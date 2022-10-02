using System.Linq;
using UnityEngine;

namespace Worms
{
    public abstract class EventListener : MonoBehaviour
    {
        [SerializeField] private Massage[] _massages;
        private EventManager _eventManager;

        protected virtual void Awake()
        {
            _eventManager = FindObjectOfType<EventManager>();
            _eventManager.OnSendMassage += OnMassageReceived;
        }

        private void OnMassageReceived(Massage msg)
        {
            if (_massages.Contains(msg))
            {
                OnEventTrigger(msg);
            }
        }

        protected abstract void OnEventTrigger(Massage msg);
    }
}