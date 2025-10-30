using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _0.Common.Scripts.BaseCore
{
    public class BaseGameOverPanel : UIPanelBase
    {
        public TextMeshProUGUI title;
        public Button btnNext;
        public Transform content;

        private void OnEnable()
        {
            content.ShowPopup();
        }

        public virtual void SetResult(bool isWin)
        {
            if (isWin) AudioManager.instance?.PlayWin();
            else AudioManager.instance?.PlayLose();
            string t = isWin ? "MISSION COMPLETE" : "MISSION FAILED";
            title.text = t;
            btnNext.interactable = isWin;
        }

        public void Home()
        {
            AudioManager.instance?.PlayButtonClick();
            Time.timeScale = 1;
            string sceneName = $"Menu";
            SceneManager.LoadScene(sceneName);
        }

        public void RestartScene()
        {
            AudioManager.instance?.PlayButtonClick();
            Time.timeScale = 1;

            string sceneName = $"{Common.GetLevelName(PlayerData.currentLevel)}";
            SceneManager.LoadScene(sceneName);
        }

        public void RestartSceneData()
        {
            AudioManager.instance?.PlayButtonClick();
            Time.timeScale = 1;

            string sceneName = $"Gameplay";
            SceneManager.LoadScene(sceneName);
        }

        public void NextScene()
        {
            AudioManager.instance?.PlayButtonClick();
            Time.timeScale = 1;
            PlayerData.currentLevel += 1;
            string sceneName = $"{Common.GetLevelName(PlayerData.currentLevel)}";
            PlayerData.currentGold += (PlayerData.currentLevel * 100);
            SceneManager.LoadScene(sceneName);
        }

        public void NextSceneData()
        {
            AudioManager.instance?.PlayButtonClick();
            Time.timeScale = 1;
            PlayerData.currentLevel += 1;
            string sceneName = $"Gameplay";
            PlayerData.currentGold += (PlayerData.currentLevel * 100);
            SceneManager.LoadScene(sceneName);
        }
    }
}