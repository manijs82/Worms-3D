using UnityEngine;

namespace Worms
{
    public abstract class TurnAction : MonoBehaviour
    {
        public virtual string ActionName => "Action";
        
        public abstract void ApplyAction(Player[] players);
        public abstract void DisableAction();
    }
}