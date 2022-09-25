using UnityEngine;

namespace Worms
{
    public class HealthPickUp : PickUp
    {
        [SerializeField] private int _healAmount;
        
        public override void GetItem(Player player)
        {
            var health = player.GetAbility<Health>();
            if(health.IsAtFullHealth) return;
            
            health.Heal(_healAmount);
            _usedAmount++;
            
            if(_usedAmount == _useLimit && _destroyOnPickUp)
                Destroy();
        }

        public override void Destroy()
        {
            Destroy(gameObject);
        }
    }
}