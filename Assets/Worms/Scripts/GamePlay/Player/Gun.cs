using UnityEngine;

namespace Worms
{
    public class Gun : Weapon
    {
        [SerializeField] private Transform _firePoint;
        [SerializeField] private Projectile _projectile;
        
        public override void Use()
        {
            Instantiate(_projectile.gameObject, _firePoint.position, Quaternion.LookRotation(_firePoint.forward));
        }
    }
}