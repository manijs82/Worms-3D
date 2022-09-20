using System.Collections.Generic;
using UnityEngine;

namespace Worms
{
    public class MovementLimiter : TurnListener
    {
        [SerializeField] private TeamManager _teamManager;
        [SerializeField] private float radius = 6;
        [SerializeField] private GameObject visuals;
        
        private Dictionary<Player, Vector3> playerPositions;

        private void Start()
        {
            playerPositions = new Dictionary<Player, Vector3>();
            
            _teamManager.OnPlayerSelected += OnPlayerActivated;
            visuals.transform.localScale = Vector3.one * radius; 
        }

        protected override void OnTurnStarted(Team team)
        {
            visuals.SetActive(true);
            playerPositions.Clear();
            
            SetPlayerPoses(team.Players);
        }

        protected override void OnTurnEnded()
        {
            visuals.SetActive(false);
        }

        private void OnPlayerActivated(Player player)
        {
            transform.position = playerPositions[player];
        }

        private void SetPlayerPoses(Player[] players)
        {
            foreach (var player in players) 
                playerPositions.Add(player, player.transform.position);
        }
    }
}