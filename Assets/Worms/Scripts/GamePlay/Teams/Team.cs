using System.Collections.Generic;
using UnityEngine;

namespace Worms
{
    [System.Serializable]
    public class Team
    {
        [SerializeField] private List<Player> _players;

        public int PlayerCount => _players.Count;

        public Team()
        {
            _players = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }
        
        public Player GetPlayer(int index)
        {
            return _players[index];
        }
    }
}