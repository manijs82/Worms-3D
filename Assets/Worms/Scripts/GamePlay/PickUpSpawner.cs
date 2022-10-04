using UnityEngine;

namespace Worms
{
    public class PickUpSpawner : TurnListener
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private PickUp[] _pickUps;
        [SerializeField] private int _maxNumOfPickUpsPerTurn = 2;
        
        protected override void OnTurnStarted(Team team)
        {
            var numOfPickUps = Random.Range(1, _maxNumOfPickUpsPerTurn + 1);

            for (int i = 0; i < numOfPickUps; i++)
            {
                var spawnPoint = GetRandomSpawnPoint();
                var pickUp = GetRandomPickUp();

                Instantiate(pickUp, spawnPoint.position, spawnPoint.rotation);
            }
        }

        protected override void OnTurnEnded() { }

        private Transform GetRandomSpawnPoint() => 
            _spawnPoints[Random.Range(0, _spawnPoints.Length)];
        
        private PickUp GetRandomPickUp() =>
            _pickUps[Random.Range(0, _pickUps.Length)];
    }
}