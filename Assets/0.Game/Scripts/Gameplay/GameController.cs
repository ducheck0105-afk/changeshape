using System;
using System.Collections.Generic;
using _0.Common.Scripts;
using _0.Common.Scripts.BaseCore;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace _0.Game.Scripts.Gameplay
{
    public class GameController : GameControllerBase
    {
        public static GameController instance;
        public List<Material> colors;
        public Player player;
        public List<MapData> levelData;
        public WallObject wallPrefabs;
        public Transform spawnPos;
        public List<WallObject> listWalls;
        private MapData currentLevel;
        private int currentShape;
        private int currentWallGroup;

        public enum ShapeType
        {
            Circle,
            Triangle,
            Rectangle
        }

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            currentLevel = levelData[PlayerData.currentLevel];
            StartLevel();
        }

        private void StartLevel()
        {
            SpawnWall();
        }

        private void SpawnWall()
        {
            var wallObjectCount = currentLevel.walls.Count;
            float posZ = 0;
            for (int i = 0; i < wallObjectCount; i++)
            {
                var obj = Instantiate(wallPrefabs);
                var wallData = currentLevel.walls[i];
                obj.transform.position = new Vector3(0, 0.5f, posZ);
                obj.SetUp(wallData);
                posZ += wallData.shapes.Count * 2.5f + 2.5f;
                listWalls.Add(obj);
            }

            UIController.instance.SetUpResult(currentLevel.walls[0].shapes);
            currentWallGroup = 0;
            currentShape = 0;
        }

        public void CorrectShape()
        {
            UIController.instance.CorrectShape(currentShape);
            currentShape += 1;
            if (currentShape >= currentLevel.walls[currentWallGroup].shapes.Count)
            {
                currentShape = 0;
                currentWallGroup += 1;
                FinishWallGroup();
            }
            else
            {
            }
        }

        private void FinishWallGroup()
        {
            if (currentWallGroup >= currentLevel.walls.Count)
            {
                // finish game
                DOVirtual.DelayedCall(1, () => { GameOver(true); });
            }
            else
            {
                UIController.instance.SetUpResult(currentLevel.walls[currentWallGroup].shapes);
            }
        }

        public void ChangeCircle()
        {
            player.ChangeCircle();
        }

        public void ChangeTriangle()
        {
            player.ChangeTriangle();
        }

        public void ChangeRectangle()
        {
            player.ChangeRectangle();
        }

        public override void GameOver(bool result)
        {
            base.GameOver(result);
            UIController.instance.ShowGameOver(result);
        }
    }
}