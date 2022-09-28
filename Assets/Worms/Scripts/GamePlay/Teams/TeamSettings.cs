using UnityEngine;

namespace Worms
{
    public class TeamSettings : MonoBehaviour
    {
        [SerializeField] private int _teamCount;
        [SerializeField] private int _playerPerTeam;

        public int TeamCount
        {
            get => _teamCount;
            set => _teamCount = value;
        }

        public int PlayerPerTeam
        {
            get => _playerPerTeam;
            set => _playerPerTeam = value;
        }
    }
}