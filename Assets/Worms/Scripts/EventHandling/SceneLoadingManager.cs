using UnityEngine.SceneManagement;

namespace Worms
{
    public class SceneLoadingManager : EventListener
    {
        protected override void OnEventTrigger(Massage msg)
        {
            if(msg == Massage.LoadGame)
                SceneManager.LoadScene(1);
            if(msg == Massage.LoadGame)
                SceneManager.LoadScene(0);
        }
    }
}