using UnityEngine;
using UnityEngine.UI;

namespace Worms
{
    [RequireComponent(typeof(Button))]
    public class ButtonMassageSender : MonoBehaviour
    {
        [SerializeField] private Massage _massage;
        private EventManager _eventManager;

        private Button button;
        
        private void Start()
        {
            _eventManager = FindObjectOfType<EventManager>();
            button = GetComponent<Button>();
            button.onClick.AddListener(SendMassage);
        }

        private void SendMassage() => 
            _eventManager.SendMassage(_massage);
    }
}