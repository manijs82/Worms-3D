using UnityEngine;

namespace Worms
{
    public class PickUpSpawner : TurnListener
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private PickUp[] _pickUps;
        [SerializeField] private float _spawnProbabality = .3f;
        
        protected override void OnTurnStarted(Team team)
        {
            var rnd = Random.value;
            if (!(rnd < _spawnProbabality)) return;
            
            SpawnPickUp();
        }

        private void SpawnPickUp()
        {
            var spawnPoint = GetRandomSpawnPoint();
            var pickUp = GetRandomPickUp();

            Instantiate(pickUp, spawnPoint.position, spawnPoint.rotation);
        }

        protected override void OnTurnEnded() { }

        private Transform GetRandomSpawnPoint() => 
            _spawnPoints[Random.Range(0, _spawnPoints.Length)];
        
        private PickUp GetRandomPickUp() =>
            _pickUps[Random.Range(0, _pickUps.Length)];
    }
}