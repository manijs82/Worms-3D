using System;
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
                StartTurn(teams[0]);
            };
            PauseManager.OnPause += paused =>
            {
                if(paused) _turnCountdown.Pause();
                else _turnCountdown.Resume();
            };
        }

        private void Update()
        {
            if(!_turnCountdown.IsTicking) return;
            
            _turnCountdown.Tick(Time.deltaTime);
            if(Input.GetKeyDown(KeyCode.F))
                _turnCountdown.Stop();
        }

        private void GoToNextTurn()
        {
            EndTurn(_temaManager.SelectedTeam);
            
            _temaManager.SelectNextTeam();
            StartTurn(_temaManager.SelectedTeam);
        }

        private void StartTurn(Team team)
        {
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

        private void OnDisable()
        {
            _turnCountdown.OnEnd -= GoToNextTurn;
            OnTurnStarted = null;
            OnTurnEnded = null;
        }
    }
}