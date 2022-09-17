using System;
using UnityEngine;

namespace Worms
{
    public class EventManager : MonoBehaviour
    {
        public event Action<Massage> OnSendMassage; 

        public void SendMassage(Massage massage)
        {
            OnSendMassage?.Invoke(massage);
        }
    }
}