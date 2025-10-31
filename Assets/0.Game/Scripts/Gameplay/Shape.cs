using System;
using System.Collections.Generic;
using _0.Common.Scripts;
using UnityEngine;

namespace _0.Game.Scripts.Gameplay
{
    public class Shape : MonoBehaviour
    {
        public GameController.ShapeType shapeType;
        public ShapeParent parent;
        public List<GameObject> shapes;
        private GameObject currentShape;
        private int index;
        public void SetUp(GameController.ShapeType shapeType, ShapeParent parent, int index)
        {
            this.shapeType = shapeType;
            this.parent = parent;
            this.index = index;
            for (int i = 0; i < shapes.Count; i++)
            {
                var obj = shapes[i];
                if (i == (int)shapeType) currentShape = obj;
                obj.SetActive(i == (int)shapeType);
            }
        }

        public void ReadyMove()
        {
            currentShape.GetComponent<MeshRenderer>().material = GameController.instance.orangeMat;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (GameController.instance.player.shape == shapeType)
                {
                    UIController.instance.CorrectShape(index);
                    parent.shapes.Remove(this);
                    if (parent.shapes.Count == 0)
                    {
                        GameController.instance.NextGroup();
                    }
                    AudioManager.instance?.PlaySfx(AudioManager.instance.ding);
                    Destroy(gameObject);
                }
                else
                {
                    GameController.instance.GameOver(false);
                }
            }
        }

    }
}