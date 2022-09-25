using UnityEngine;

namespace Worms
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private Health _health;
        private Material _material;
        private Transform _cam;

        private void Start()
        {
            _health = _player.GetAbility<Health>();
            _material = GetComponent<Renderer>().material;
            _cam = _player.cam;

            _health.OnHealthChange += _ => UpdateHealthBar();
            UpdateHealthBar();
        }

        private void Update()
        {
            transform.rotation = Quaternion.LookRotation(_cam.forward, Vector3.up);
        }

        private void UpdateHealthBar()
        {
            _material.SetFloat("_HealthAmount", _health.HealthPercentage);
        }
    }
}
