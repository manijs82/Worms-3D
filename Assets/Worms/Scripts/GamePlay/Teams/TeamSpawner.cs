using System;
using UnityEngine;

namespace Worms
{
    public class TeamSpawner : EventListener
    {
        public event Action OnSpawnTeams;
        
        [SerializeField] private TeamsSpawnPoint _spawnPoints;
        [SerializeField] private TeamSettings _teamSettings;
        [SerializeField] private Player _playerPrefab;
        
        protected override void OnEventTrigger(Massage msg)
        {
            SpawnTeams(_teamSettings.TeamCount, _teamSettings.PlayerPerTeam);
        }

        private void SpawnTeams(int teamCount, int playerPerTeam)
        {
            for (int i = 0; i < teamCount; i++)
            {
                var teamGo = new GameObject("Team" + i);
                teamGo.transform.SetParent(transform);
                
                for (int j = 0; j < playerPerTeam; j++)
                    SpawnPlayer(i, j);
            }
            OnSpawnTeams?.Invoke();
        }

        private void SpawnPlayer(int teamIndex, int playerIndex)
        {
            var spawnTr = _spawnPoints.GetSpawnPoint(teamIndex, playerIndex);
            var parent = transform.GetChild(teamIndex);
            
            Instantiate(_playerPrefab, spawnTr.position, spawnTr.rotation, parent);
        }
    }
}