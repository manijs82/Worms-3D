using UnityEngine;

namespace Worms
{
    public class AlterMovementLimitAction : TurnAction
    {
        public override string ActionName => "Change Movement Limit Radius";
        
        [SerializeField] private MovementLimiter _limiter;
        [SerializeField] private float _radiusMultiplier = 2;
        
        private float _baseRadius;
        
        public override void ApplyAction(Player[] players)
        {
            _baseRadius = _limiter.Radius;
            _limiter.ChangeRadius(_baseRadius * _radiusMultiplier);
        }

        public override void DisableAction()
        {
            _limiter.ChangeRadius(_baseRadius);
        }
    }
}