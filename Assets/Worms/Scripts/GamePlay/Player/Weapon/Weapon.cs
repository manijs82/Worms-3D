using UnityEngine;

namespace Worms
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected AudioClip _audioClip;
        
        protected WeaponHandler _owner;
        protected bool _activeSelf;

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
            _activeSelf = true;
            gameObject.SetActive(true);
        }

        public virtual void DeActivate()
        {
            _activeSelf = false;
            gameObject.SetActive(false);
        }

        protected virtual void DealDamage(Health[] healths, int amount)
        {
            foreach (var health in healths)
            {
                health.Damage(amount);
            }
        }

        protected virtual void PlaySound()
        {
            if(_audioClip == null) return;
            
            SoundManager.Instance.PlaySound(_audioClip);
        }
    }
}