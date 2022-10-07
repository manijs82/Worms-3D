using UnityEngine;

namespace Worms
{
    public class ChooseWeaponAction : TurnAction
    {
        [SerializeField] private int _weapoIndex;
        [SerializeField] private string _name;
        
        private WeaponHandler[] handlers;

        public override string ActionName => _name;
        
        public override void ApplyAction(Player[] players)
        {
            handlers = new WeaponHandler[players.Length];
            for (int i = 0; i < handlers.Length; i++)
            {
                handlers[i] = players[i].GetAbility<WeaponHandler>();
                handlers[i].EquipWeapon(_weapoIndex);
            }
        }

        public override void DisableAction()
        {
            foreach (var handler in handlers)
                handler.UnEquipCurrentWeapon();
        }
    }
}