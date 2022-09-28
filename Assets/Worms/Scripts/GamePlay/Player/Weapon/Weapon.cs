using Unity.VisualScripting;
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

            DeActivate();
            return go.GetComponent<Weapon>();
        }

        public virtual void Activate()
        {
            gameObject.SetActive(true);
        }

        public virtual void DeActivate()
        {
            gameObject.SetActive(false);
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