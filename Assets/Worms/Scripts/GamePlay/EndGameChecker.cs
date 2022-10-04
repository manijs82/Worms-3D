using UnityEngine;

namespace Worms
{
    public class EndGameChecker : MassageSender
    {
        [SerializeField] private TeamManager _temaManager;
        [SerializeField] private TeamSettings _teamSettings;
        
        private int _deadTeams;
        
        private void Start()
        {
            _temaManager.OnTeamsInitialized += teams =>
            {
                foreach (var team in teams)
                {
                    team.OnAllDeath += Check;
                }
            };
        }

        private void Check()
        {
            _deadTeams++;
            if (_deadTeams == _teamSettings.TeamCount - 1)
                EndGame();
        }

        private void EndGame()
        {
            SendMassage();
        }
    }
}