using UnityEngine;

namespace Worms
{
    public class MassageSender : MonoBehaviour
    {
        [SerializeField] protected Massage _massage;
        protected EventManager _eventManager;

        private void Awake()
        {
            _eventManager = FindObjectOfType<EventManager>();
        }

        protected virtual void SendMassage() => 
            _eventManager.SendMassage(_massage);
        
        protected virtual void SendMassage(Massage massage) => 
            _eventManager.SendMassage(massage);
    }
}