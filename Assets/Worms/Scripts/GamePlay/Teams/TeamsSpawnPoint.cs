using UnityEngine;

namespace Worms
{
    public class TeamsSpawnPoint : MonoBehaviour
    {
        [SerializeField] private TeamSpawnPoints[] _teamSpawnPoints;

        public Transform GetSpawnPoint(int teamIndex, int playerIndex) => 
            _teamSpawnPoints[teamIndex].points[playerIndex];
    }

    [System.Serializable]
    public struct TeamSpawnPoints
    {
        public Transform[] points;
    }
}