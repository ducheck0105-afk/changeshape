using UnityEngine;
using UnityEngine.SceneManagement;

namespace _0.Common.Scripts.BaseCore
{
    public class BaseUIGameplay : MonoBehaviour
    {
        public BaseGameOverPanel gameOver;
        public virtual void Pause()
        {
            AudioManager.instance?.PlayButtonClick();
        }


        public void Home()
        {
            AudioManager.instance?.PlayButtonClick();
            Time.timeScale = 1;
            string sceneName = $"Menu";
            SceneManager.LoadScene(sceneName);
        }
    }
}