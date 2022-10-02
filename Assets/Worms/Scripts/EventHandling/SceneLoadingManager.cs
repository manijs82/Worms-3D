using UnityEngine.SceneManagement;

namespace Worms
{
    public class SceneLoadingManager : EventListener
    {
        protected override void OnEventTrigger(Massage msg)
        {
            SceneManager.LoadScene(1);
        }
    }
}