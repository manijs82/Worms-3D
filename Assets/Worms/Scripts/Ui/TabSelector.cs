using UnityEngine;

namespace Project.Scripts
{
    public class TabSelector : MonoBehaviour
    {
        [SerializeField] private Tab[] tabs;

        public void SelectTab(int id)
        {
            foreach (var tab in tabs)
            {
                tab.DeSelect();    
            }
            tabs[id].Select();
        }
    }
}