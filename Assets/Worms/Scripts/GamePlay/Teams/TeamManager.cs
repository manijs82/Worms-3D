using System;
using UnityEngine;

namespace Worms
{
    [RequireComponent(typeof(TeamSpawner))]
    public class TeamManager : MonoBehaviour
    {
        public event Action<Player> OnPlayerSelected;
        
        [SerializeField] private Team[] _teams;
        private int _selectedTeamIndex;
        private int _selectedPlayerIndex = -1;

        private Team SelectedTeam => _teams[_selectedTeamIndex];

        private void Awake()
        {
            GetComponent<TeamSpawner>().OnSpawnTeams += InitializeTeams;
        }

        private void InitializeTeams()
        {
            _teams = new Team[transform.childCount];
            
            for (int i = 0; i < _teams.Length; i++)
            {
                var team = new Team();
                _teams[i] = team;

                var teamTr = transform.GetChild(i);
                for (int j = 0; j < teamTr.childCount; j++) 
                    team.AddPlayer(teamTr.GetChild(j).GetComponent<Player>());
            }

            SelectNextPlayer();
        }

        private void Update()
        {
            if(Input.mouseScrollDelta.y > 0.1f)
                SelectNextPlayer();
            if(Input.mouseScrollDelta.y < -0.1f)
                SelectPreviousPlayer();
        }

        private void SelectNextPlayer()
        {
            DeselectCurrentPlayer();

            _selectedPlayerIndex++;
            if (_selectedPlayerIndex >= SelectedTeam.PlayerCount)
                _selectedPlayerIndex = 0;
            SelectPlayer(_selectedPlayerIndex);
        }

        private void SelectPreviousPlayer()
        {
            DeselectCurrentPlayer();

            _selectedPlayerIndex--;
            if (_selectedPlayerIndex <= -1)
                _selectedPlayerIndex = SelectedTeam.PlayerCount - 1;
            SelectPlayer(_selectedPlayerIndex);
        }

        private void SelectPlayer(int index)
        {
            var player = SelectedTeam.GetPlayer(index);
            player.isActive = true;
            
            OnPlayerSelected?.Invoke(player);
        }

        private void DeselectCurrentPlayer()
        {
            if(_selectedPlayerIndex == -1) return;
            SelectedTeam.GetPlayer(_selectedPlayerIndex).isActive = false;
        }
    }
}