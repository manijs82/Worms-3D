using UnityEngine;

namespace Worms
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected AudioClip _audioClip;
        [SerializeField] protected int _usePerTurn = 2;
        
        protected WeaponHandler _owner;
        protected bool _activeSelf;
        protected int _useCount;

        public virtual void Use()
        {
            _useCount++;
            if(_useCount >= _usePerTurn)
                DeActivate();
        }

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
            _useCount = 0;
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