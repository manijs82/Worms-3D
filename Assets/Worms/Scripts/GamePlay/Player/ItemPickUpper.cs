using UnityEngine;
using UnityEngine.InputSystem;

namespace Worms
{
    public class ItemPickUpper : Ability
    {
        [SerializeField] private float _pickUpRange = 2;
        
        public override void Initialize(Player owner)
        {
            base.Initialize(owner);

            _owner.input.actions["PickUp"].performed += PickUpItem;
        }

        private void PickUpItem(InputAction.CallbackContext ctx)
        {
            if(!_owner.IsActive) return;

            var colliders = Physics.OverlapBox(transform.position, Vector3.one * _pickUpRange);
            foreach (var col in colliders)
            {
                var pickUp = col.GetComponent<PickUp>();
                if (pickUp == null) continue;
                
                pickUp.GetItem(_owner);
            }
        }
        
        private void OnDisable()
        {
            if(_owner.input == null) return;
            _owner.input.actions["PickUp"].performed -= PickUpItem;
        }
    }
}