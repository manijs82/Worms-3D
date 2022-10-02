using UnityEngine;

namespace Worms
{
    public class GernadLauncher : Weapon
    {
        [SerializeField] private Transform _firePoint;
        [SerializeField] private Gernad gernad;
        [SerializeField] private float _force;
        
        public override void Use()
        {
            if(!_activeSelf) return;
            
            var go = Instantiate(gernad.gameObject, _firePoint.position, Quaternion.LookRotation(_firePoint.forward));
            go.GetComponent<Rigidbody>().AddForce(go.transform.forward * _force, ForceMode.Impulse);
        }
    }
}