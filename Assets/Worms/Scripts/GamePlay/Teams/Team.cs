using System;
using System.Collections.Generic;
using UnityEngine;

namespace Worms
{
    [Serializable]
    public class Team
    {
        public event Action OnEndTurn;
        
        [SerializeField] private List<Player> _players;

        public int PlayerCount => _players.Count;
        public Player[] Players => _players.ToArray();

        public Team()
        {
            _players = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            _players.Add(player);
            player.OnPerformAction += EndTurn;
        }
        
        public Player GetPlayer(int index)
        {
            return _players[index];
        }

        private void EndTurn()
        {
            OnEndTurn?.Invoke();
        }
    }
}