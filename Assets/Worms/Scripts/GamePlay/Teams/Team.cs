using System;
using System.Collections.Generic;
using UnityEngine;

namespace Worms
{
    [Serializable]
    public class Team
    {
        public event Action OnAllDeath;
        
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
            player.GetAbility<Health>().OnDeath += () => RemovePlayer(player);
        }

        private void RemovePlayer(Player player)
        {
            _players.Remove(player);
            if(_players.Count == 0)
                OnAllDeath?.Invoke();
        }

        public Player GetPlayer(int index)
        {
            return _players[index];
        }
    }
}