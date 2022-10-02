using System;
using UnityEngine;

namespace Worms
{
    public class ActionChooserUi : MonoBehaviour
    {
        public event Action<TurnAction> OnChooseAction;
        
        [SerializeField] private ActionChooserButton _chooser;

        private Transform _root;

        private void Start()
        {
            _root = transform.GetChild(0);
        }

        public void StartChoosing(TurnAction[] turnActions)
        {
            foreach (var turnAction in turnActions)
            {
                ActionChooserButton btn = Instantiate(_chooser, _root);
                btn.Initialize(turnAction);
                btn.OnClickOnAction += Choose;
            }
        }

        private void Choose(TurnAction turnAction)
        {
            DestroyChoosers();
            OnChooseAction?.Invoke(turnAction);
        }
        
        public void DestroyChoosers()
        {
            for (int i = _root.childCount - 1; i >= 0; i--) 
                Destroy(_root.GetChild(i).gameObject);
        }
    }
}