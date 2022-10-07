using System;
using UnityEngine;

namespace Worms
{
    public class ActionChooser : TurnListener
    {
        public event Action OnApplyAction;
        
        [SerializeField] private ActionChooserUi _actionChooserUi;
        [SerializeField] private TurnAction[] _turnActions;

        private Team _currentTeam;
        private TurnAction _selectedAction;
        private void Start()
        {
            _actionChooserUi.OnChooseAction += ApplyAction;
        }

        protected override void OnTurnStarted(Team team)
        {
            _currentTeam = team;
            _actionChooserUi.StartChoosing(_turnActions);
        }

        private void ApplyAction(TurnAction turnAction)
        {
            _selectedAction = turnAction;
            _selectedAction.ApplyAction(_currentTeam.Players);
            OnApplyAction?.Invoke();
        }

        protected override void OnTurnEnded()
        {
            _actionChooserUi.DestroyChoosers();
            if(_selectedAction != null)
                _selectedAction.DisableAction();
        }

        private void OnDisable()
        {
            _actionChooserUi.OnChooseAction -= ApplyAction;
        }
    }
}