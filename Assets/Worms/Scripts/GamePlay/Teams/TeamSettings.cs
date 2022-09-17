using UnityEngine;

namespace Worms
{
    public class TeamSettings : MonoBehaviour
    {
        [SerializeField] private int _teamCount;
        [SerializeField] private int _playerPerTeam;

        public int TeamCount => _teamCount;
        public int PlayerPerTeam => _playerPerTeam;
    }
}