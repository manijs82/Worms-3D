using UnityEngine;
using UnityEngine.UI;

namespace Worms
{
    [RequireComponent(typeof(Button))]
    public class ButtonMassageSender : MassageSender
    {
        private Button button;
        
        private void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(SendMassage);
        }
    }
}