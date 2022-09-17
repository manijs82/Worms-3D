using UnityEngine;

namespace Worms
{
    public class UiPanel : EventListener
    {
        private GameObject _panel;
        private bool _active;

        private void Start()
        {
            _panel = transform.GetChild(0).gameObject;
            _active = _panel.activeSelf;
        }

        protected override void Action(Massage msg)
        {
            TogglePanel();
        }

        private void TogglePanel()
        {
            if (!_active)
                EnablePanel();
            else
                DisablePanel();
        }

        protected virtual void EnablePanel()
        {
            _active = true;
            _panel.SetActive(_active);
        }

        protected virtual void DisablePanel()
        {
            _active = false;
            _panel.SetActive(_active);
        }
    }
}