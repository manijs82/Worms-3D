using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Worms
{
    public class WeaponHandler : Ability
    {
        public Weapon[] initialWeapons;
        public Transform weaponAttachment;

        private List<Weapon> _weapons;
        private Weapon _currentWeapon;
        
        public override void Initialize(Player owner)
        {
            base.Initialize(owner);
            _weapons = new List<Weapon>();

            foreach (var weapon in initialWeapons)
            {
                var newWeapon = weapon.Spawn(this);
                _weapons.Add(newWeapon);
            }

            _owner.input.actions["Fire"].performed += UseWeapon;
        }

        private void UseWeapon(InputAction.CallbackContext ctx)
        {
            if(!_owner.IsActive || _currentWeapon == null) return;
            
            _currentWeapon.Use();
        }
    }
}