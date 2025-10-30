using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _0.Game.Scripts.Gameplay
{
    public class Wall : MonoBehaviour
    {
        public GameController.ShapeType type;
        public GameObject circleObject;
        public GameObject  triangleObject;
        public GameObject   rectangleObject;
        public void SetUp(GameController.ShapeType type)
        {
            this.type = type;
            circleObject.SetActive(type == GameController.ShapeType.Circle);
            triangleObject.SetActive(type == GameController.ShapeType.Triangle);
            rectangleObject.SetActive(type == GameController.ShapeType.Rectangle);
            var randomColor = GameController.instance.colors[Random.Range(0, GameController.instance.colors.Count)];
            circleObject.GetComponent<MeshRenderer>().material = randomColor;
            triangleObject.GetComponent<MeshRenderer>().material = randomColor;
            rectangleObject.GetComponent<MeshRenderer>().material = randomColor;
        }

        

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var player = other.GetComponent<Player>();
                if (player.type == type)
                {
                    GameController.instance.CorrectShape();
                }
                else
                {
                    GameController.instance.GameOver(false);
                }
            }
        }
    }
}