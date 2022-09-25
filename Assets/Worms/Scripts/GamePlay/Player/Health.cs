using System;
using UnityEngine;

namespace Worms
{
    public class Health : Ability
    {
        public event Action<int> OnHealthChange;
        public event Action OnDeath;
        
        [SerializeField] private int _initialHealth;
        [SerializeField] private int _maxHealth;
        
        private int _health;
        private bool _isDead;

        public bool IsAtFullHealth => _health == _maxHealth;
        public float HealthPercentage => (float) _health / _maxHealth;

        public override void Initialize(Player owner)
        {
            base.Initialize(owner);
            _health = _initialHealth;
        }

        public void Heal(int amount)
        {
            if(_isDead) return;
            
            _health += amount;

            if (_health > _maxHealth)
            {
                _health = _maxHealth;
            }
            
            OnHealthChange?.Invoke(_health);
        }

        public void Damage(int amount)
        {
            if(_isDead) return;

            _health -= amount;

            if (_health <= 0)
            {
                _health = 0;
                Die();
            }
            
            OnHealthChange?.Invoke(_health);
        }

        private void Die()
        {
            _isDead = true;
            OnDeath?.Invoke();
            
            Destroy(gameObject);
        }
    }
}