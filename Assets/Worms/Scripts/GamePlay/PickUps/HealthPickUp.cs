using UnityEngine;

namespace Worms
{
    public class HealthPickUp : PickUp
    {
        [SerializeField] private int _healAmount;

        private Material _material;

        private void Start()
        {
            _material = GetComponent<Renderer>().material;
        }

        public override void GetItem(Player player)
        {
            var health = player.GetAbility<Health>();
            if(health.IsAtFullHealth) return;
            
            health.Heal(_healAmount);
            
            OnUse();

            if(_usedAmount == _useLimit && _destroyOnPickUp)
                Destroy();
        }

        private void OnUse()
        {
            _usedAmount++;
            _material.SetFloat("_HealthAmount", (float)_usedAmount / _useLimit);
            PlaySound();
        }

        public override void Destroy()
        {
            Destroy(gameObject);
        }
    }
}