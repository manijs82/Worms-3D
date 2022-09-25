using System.Collections;
using UnityEngine;

namespace Worms
{
    public class Gernad : MonoBehaviour
    {
        [SerializeField] private float _explodeTimer = 3;
        [SerializeField] private float _range = 5;
        [SerializeField] private int _damage;
        
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(_explodeTimer);

            Explode();
        }

        private void Explode()
        {
            var colliders = Physics.OverlapSphere(transform.position, _range);

            foreach (var col in colliders)
            {
                var health = col.GetComponent<Health>();
                if(health == null) continue;
                
                health.Damage(_damage);
            }
        }
    }
}