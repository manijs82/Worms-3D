using System;
using UnityEngine;
using UnityEngine.UI;

namespace Worms
{
    [RequireComponent(typeof(Button))]
    public class QuitButton : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(Application.Quit);
        }
    }
}