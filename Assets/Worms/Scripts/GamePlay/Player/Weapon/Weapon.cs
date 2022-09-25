using UnityEngine;

namespace Worms
{
    public abstract class Weapon : MonoBehaviour
    {
        protected WeaponHandler _owner;

        public abstract void Use();

        public virtual Weapon Spawn(WeaponHandler weaponHandler)
        {
            _owner = weaponHandler;
            var go = Instantiate(gameObject, weaponHandler.weaponAttachment);
            go.transform.localPosition = Vector3.zero;
            
            go.SetActive(false);
            return go.GetComponent<Weapon>();
        }

        protected virtual void DealDamage(Health[] healths, int amount)
        {
            foreach (var health in healths)
            {
                health.Damage(amount);
            }
        }
    }
}