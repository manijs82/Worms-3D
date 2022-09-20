using TMPro;
using UnityEngine;

namespace Worms
{
    public class TurnTimerHud : MonoBehaviour
    {
        [SerializeField] private TurnManager turnManager;
        [SerializeField] private TextMeshProUGUI timerText;

        private void Update()
        {
            timerText.text = turnManager.CurrentTime.ToString("00");
        }
    }
}