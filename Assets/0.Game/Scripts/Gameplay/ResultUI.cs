using UnityEngine;
using UnityEngine.UI;

namespace _0.Game.Scripts.Gameplay
{
    public class ResultUI : MonoBehaviour
    {
        public Image icon;
        public Image main;

        public void setUp(Sprite icon)
        {
            Debug.Log("setup ");
            this.icon.sprite = icon;
            this.main.color = Color.white;
        }


        public void Correct()
        {
            Debug.Log($"Correct {gameObject.name}");
            main.color = Color.green;
        }
    }
}