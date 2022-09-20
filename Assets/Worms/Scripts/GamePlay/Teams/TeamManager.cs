using System;
using System.Collections;
using UnityEngine;

namespace Worms
{
    [RequireComponent(typeof(TeamSpawner))]
    public class TeamManager : MonoBehaviour
    {
        public event Action<Player> OnPlayerSelected;
        public event Action<Team[]> OnTeamsInitialized;
        
        [SerializeField] private Team[] _teams;
        private int _selectedTeamIndex;
        private int _selectedPlayerIndex = -1;

        public Team SelectedTeam => _teams[_selectedTeamIndex];

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
            
            OnTeamsInitialized?.Invoke(_teams);

            SelectNextPlayer();
        }

        private void Update()
        {
            if(Input.mouseScrollDelta.y > 0.1f)
                SelectNextPlayer();
            if(Input.mouseScrollDelta.y < -0.1f)
                SelectPreviousPlayer();
        }

        public void SelectNextTeam()
        {
            DeselectCurrentPlayer();
            _selectedPlayerIndex = 0;
            
            _selectedTeamIndex++;
            if (_selectedTeamIndex >= _teams.Length)
                _selectedTeamIndex = 0;
            
            StartCoroutine(SelectPlayer(0));
        }

        private void SelectNextPlayer()
        {
            DeselectCurrentPlayer();

            _selectedPlayerIndex++;
            if (_selectedPlayerIndex >= SelectedTeam.PlayerCount)
                _selectedPlayerIndex = 0;
            StartCoroutine(SelectPlayer(_selectedPlayerIndex));
        }

        private void SelectPreviousPlayer()
        {
            DeselectCurrentPlayer();

            _selectedPlayerIndex--;
            if (_selectedPlayerIndex <= -1)
                _selectedPlayerIndex = SelectedTeam.PlayerCount - 1;
            StartCoroutine(SelectPlayer(_selectedPlayerIndex));
        }

        private IEnumerator SelectPlayer(int index)
        {
            yield return new WaitForEndOfFrame();
            var player = SelectedTeam.GetPlayer(index);
            player.IsActive = true;
            
            OnPlayerSelected?.Invoke(player);
        }

        private void DeselectCurrentPlayer()
        {
            if(_selectedPlayerIndex == -1) return;
            SelectedTeam.GetPlayer(_selectedPlayerIndex).IsActive = false;
        }
    }
}