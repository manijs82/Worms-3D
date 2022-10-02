using System.Collections.Generic;
using UnityEngine;

namespace Worms
{
    public class MovementLimiter : TurnListener
    {
        [SerializeField] private TeamManager _teamManager;
        [SerializeField] private float _radius = 6;
        [SerializeField] private GameObject _visuals;
        
        private Dictionary<Player, Vector3> _playerPositions;

        public float Radius => _radius;

        private void Start()
        {
            _playerPositions = new Dictionary<Player, Vector3>();
            
            _teamManager.OnPlayerSelected += OnPlayerActivated;
            _visuals.transform.localScale = Vector3.one * _radius; 
        }

        protected override void OnTurnStarted(Team team)
        {
            _visuals.SetActive(true);
            _playerPositions.Clear();
            
            SetPlayerPoses(team.Players);
        }

        protected override void OnTurnEnded()
        {
            _visuals.SetActive(false);
        }

        private void OnPlayerActivated(Player player)
        {
            transform.position = _playerPositions[player];
        }

        private void SetPlayerPoses(Player[] players)
        {
            foreach (var player in players) 
                _playerPositions.Add(player, player.transform.position);
        }

        public void ChangeRadius(float newRadius)
        {
            _radius = newRadius;
            _visuals.transform.localScale = Vector3.one * _radius; 
        }
    }
}