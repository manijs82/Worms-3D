using UnityEngine;
using UnityEngine.InputSystem;

namespace Worms
{
    public class WeaponHandler : Ability
    {
        public Weapon initialWeapon;
        public Transform weaponAttachment;

        private Weapon _currentWeapon;
        
        public override void Initialize(Player owner)
        {
            base.Initialize(owner);
            _currentWeapon = initialWeapon.Spawn(this);

            _owner.input.actions["Fire"].performed += UseWeapon;
        }

        private void UseWeapon(InputAction.CallbackContext ctx)
        {
            if(!_owner.IsActive) return;
            
            _currentWeapon.Use();
        }
        
        private void OnDisable()
        {
            if(_owner.input == null) return;
            _owner.input.actions["Fire"].performed -= UseWeapon;
        }
    }
}