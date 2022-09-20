using System;
using System.Collections;
using UnityEngine;

namespace Worms
{
    public class TurnManager : MonoBehaviour
    {
        public event Action<Team> OnTurnStarted;
        public event Action OnTurnEnded;
        
        [SerializeField] private TeamManager _temaManager;
        [SerializeField] private float _turnTime;
        [SerializeField] private float _betweenTurnTime;
        
        private Countdown _turnCountdown;

        public float CurrentTime => _turnCountdown.CurrentTime;
        
        private void Start()
        {
            _turnCountdown = new Countdown(_turnTime);
            _turnCountdown.OnEnd += GoToNextTurn;
            
            _temaManager.OnTeamsInitialized += teams =>
            {
                StartCoroutine(StartTurn(teams[0]));
                foreach (var team in teams)
                    team.OnEndTurn += GoToNextTurn;
            };
        }

        private void Update()
        {
            _turnCountdown.Tick(Time.deltaTime);
        }

        private void GoToNextTurn()
        {
            EndTurn(_temaManager.SelectedTeam);
            
            _temaManager.SelectNextTeam();
            StartCoroutine(StartTurn(_temaManager.SelectedTeam));
        }

        private IEnumerator StartTurn(Team team)
        {
            yield return new WaitForSeconds(_betweenTurnTime);
            foreach (var player in team.Players) 
                player.StartTurn();
            
            _turnCountdown.Start();
            OnTurnStarted?.Invoke(team);
        }
        
        private void EndTurn(Team team)
        {
            foreach (var player in team.Players) 
                player.EndTurn();
            
            OnTurnEnded?.Invoke();
        }
        
    }
}