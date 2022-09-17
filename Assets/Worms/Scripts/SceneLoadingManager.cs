using UnityEngine.SceneManagement;

namespace Worms
{
    public class SceneLoadingManager : EventListener
    {
        protected override void Action(Massage msg)
        {
            SceneManager.LoadScene(1);
        }
    }
}