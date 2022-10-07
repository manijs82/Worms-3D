using UnityEngine;

namespace Worms
{
    public class Gun : Weapon
    {
        [SerializeField] private Transform _firePoint;
        [SerializeField] private Projectile _projectile;
        
        public override void Use()
        {
            if (!_activeSelf) return;
            
            Instantiate(_projectile.gameObject, _firePoint.position, Quaternion.LookRotation(_firePoint.forward));
            PlaySound();
            
            base.Use();
        }
    }
}