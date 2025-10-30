using System;
using System.Collections.Generic;
using _0.Common.Scripts;
using _0.Common.Scripts.BaseCore;
using TMPro;
using UnityEngine;

namespace _0.Game.Scripts.Gameplay
{
    public class UIController : BaseUIGameplay
    {
        public static UIController instance;
        public GameObject startObj;
        public List<Sprite> icon;
        public List<ResultUI> results;
        public TextMeshProUGUI levelText;
        private void Awake()
        {
            instance = this;
            levelText.text = $"Level {PlayerData.currentLevel + 1}";
        }

        public void CorrectShape(int currentShape)
        {
            results[currentShape].Correct();
        }
        public void SetUpResult(List<GameController.ShapeType> shape)
        {
            for (int i = 0; i < results.Count; i++)
            {
                var resultUI = results[i];
                resultUI.gameObject.SetActive(i < shape.Count);
                if (i < shape.Count)
                {
                    var shapeType = shape[i];
                    resultUI.setUp(icon[(int)shapeType]);
                }
            }
        }

        public void TapToStart()
        {
            AudioManager.instance?.PlayButtonClick();
            startObj.SetActive(false);
            GameController.instance.gameOver = false;
        }
        public void ChangeCircle()
        {
            AudioManager.instance?.PlayButtonClick();
            GameController.instance.ChangeCircle();
        }

        public void ChangeTriangle()
        {
            AudioManager.instance?.PlayButtonClick();
            GameController.instance.ChangeTriangle();
        }

        public void ChangeRectangle()
        {
            AudioManager.instance?.PlayButtonClick();
            GameController.instance.ChangeRectangle();
        }

        public void ShowGameOver(bool result)
        {
            gameOver.SetResult(result);
            gameOver.gameObject.SetActive(true);
        }

        public override void Pause()
        {
            base.Pause();
            settting.gameObject.SetActive(true);
        }
    }
}