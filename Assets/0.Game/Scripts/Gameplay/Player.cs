using System;
using UnityEngine;

namespace _0.Game.Scripts.Gameplay
{
    public class Player : MonoBehaviour
    {
        public Rigidbody rb;
        public float speed;

        public GameObject circle;
        public GameObject rectangle;
        public GameObject triangle;

        public GameController.ShapeType type;
        private void FixedUpdate()
        {
            if(GameController.instance.gameOver) return;
            rb.MovePosition(rb.position + transform.forward * speed * Time.fixedDeltaTime);
        }
        
        public void ChangeCircle()
        {
            circle.gameObject.SetActive(true);
            rectangle.gameObject.SetActive(false);
            triangle.gameObject.SetActive(false);
            type = GameController.ShapeType.Circle;
        }

        public void ChangeTriangle()
        {
            circle.gameObject.SetActive(false);
            rectangle.gameObject.SetActive(false);
            triangle.gameObject.SetActive(true);
            type = GameController.ShapeType.Triangle;
        }

        public void ChangeRectangle()
        {
            circle.gameObject.SetActive(false);
            rectangle.gameObject.SetActive(true);
            triangle.gameObject.SetActive(false);
            type = GameController.ShapeType.Rectangle;
        }
    }
}