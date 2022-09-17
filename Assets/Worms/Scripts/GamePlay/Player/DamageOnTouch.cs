using UnityEngine;

namespace Worms
{
    [RequireComponent(typeof(Collider))]
    public class DamageOnTouch : MonoBehaviour
    {
        [SerializeField] private int _damage = 1;
        [SerializeField] private bool _destroyOnTouch;

        private void OnCollisionEnter(Collision other)
        {
            OnTouch(other.gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            OnTouch(other.gameObject);
        }

        protected virtual void OnTouch(GameObject go)
        {
            DamageObject(go);

            if (_destroyOnTouch)
            {
                Destroy(gameObject);
            }
        }

        private void DamageObject(GameObject go)
        {
            Health health = go.GetComponent<Health>();
            if (health == null) return;
            health.Damage(_damage);
        }
    }
}