using UnityEngine;

namespace Worms
{
    public abstract class PickUp : MonoBehaviour
    {
        [SerializeField] protected bool _destroyOnPickUp = true;
        [SerializeField] protected int _useLimit = 1;
        [SerializeField] private AudioClip _audioClip;
        
        protected int _usedAmount;
        
        public abstract void GetItem(Player player);
        public abstract void Destroy();

        protected void PlaySound()
        {
            SoundManager.Instance.PlaySound(_audioClip);
        }
    }
}