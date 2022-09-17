using UnityEngine;

namespace Worms
{
    public abstract class Ability : MonoBehaviour
    {
        private bool _active = true;
        protected Player _owner;

        public virtual void Initialize(Player owner) =>
            _owner = owner;

        public void Use()
        {
            if(_active)
                PerformAction();
        }
        
        protected virtual void PerformAction() { }
    }
}