using UnityEngine;

namespace Worms
{
    public class Projectile : DamageOnTouch
    {
        [SerializeField] private int _speed;

        private void Start()
        {
            Destroy(gameObject, 7);
        }

        private void Update()
        {
            transform.position += transform.forward * (_speed * Time.deltaTime);
        }
    }
}