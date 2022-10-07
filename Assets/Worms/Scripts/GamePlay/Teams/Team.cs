using System;
using System.Collections.Generic;
using UnityEngine;

namespace Worms
{
    [Serializable]
    public class Team
    {
        public event Action OnAllDeath;
        public event Action OnPlayerDeath;
        
        [SerializeField] private List<Player> _players;

        public bool IsDead { get; private set; }
        public int MaxPlayers { get; private set; }
        public int PlayerCount => _players.Count;
        public Player[] Players => _players.ToArray();
        

        public Team(int playerCount)
        {
            _players = new List<Player>();
            MaxPlayers = playerCount;
        }

        public void AddPlayer(Player player)
        {
            _players.Add(player);
            player.GetAbility<Health>().OnDeath += () => RemovePlayer(player);
        }

        private void RemovePlayer(Player player)
        {
            _players.Remove(player);
            OnPlayerDeath?.Invoke();
            if(_players.Count == 0)
            {
                IsDead = true;
                OnAllDeath?.Invoke();
            }
        }

        public Player GetPlayer(int index)
        {
            return _players[index];
        }
    }
}