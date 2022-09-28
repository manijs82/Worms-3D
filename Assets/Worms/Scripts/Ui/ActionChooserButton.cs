using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Worms
{
    public class ActionChooserButton : MonoBehaviour
    {
        public event Action<TurnAction> OnClickOnAction;

        private TurnAction _currentAction;
        private Button _button;
        private TextMeshProUGUI _text;

        public void Initialize(TurnAction turnAction)
        {
            _currentAction = turnAction;
            
            _button = GetComponent<Button>();
            _text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            _text.text = turnAction.ActionName;
            
            _button.onClick.AddListener(() => OnClickOnAction?.Invoke(_currentAction));
        }
    }
}