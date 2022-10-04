using UnityEngine;

namespace Project.Scripts
{
    public class Tab : MonoBehaviour
    {
        public void Select()
        {
            gameObject.SetActive(true);
        }
        
        public void DeSelect()
        {
            gameObject.SetActive(false);
        }
    }
}