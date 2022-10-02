using UnityEngine;

namespace Worms
{
    public class TeamStatsUi : MonoBehaviour
    {
        [SerializeField] private TeamManager _teamManager;
        [SerializeField] private TurnManager _turnManager;
        [SerializeField] private TeamStatPanel _teamStatPanel;
        [SerializeField] private Transform _root;

        private TeamStatPanel[] _panels;
        
        private void Start()
        {
            _teamManager.OnTeamsInitialized += InitializeTeamPanels;
            _turnManager.OnTurnStarted += HighLightTeamPanel;
        }

        private void HighLightTeamPanel(Team team)
        {
            foreach (var panel in _panels)
            {
                if(panel.team == team)
                {
                    panel.HighLightPanel(true);
                    continue;
                }

                panel.HighLightPanel(false);
            }
        }

        private void InitializeTeamPanels(Team[] teams)
        {
            _panels = new TeamStatPanel[teams.Length];
            
            int i = 0;
            foreach (var team in teams)
            {
                TeamStatPanel panel = Instantiate(_teamStatPanel, _root);
                panel.Initialize(team, i);
                _panels[i] = panel;
                
                i++;
            }
        }
    }
}