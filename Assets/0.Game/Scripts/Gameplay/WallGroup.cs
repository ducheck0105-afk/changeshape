using System.Collections.Generic;
using UnityEngine;

namespace _0.Game.Scripts.Gameplay
{
    public class WallGroup : MonoBehaviour
    {
        public List<Wall> walls;
        
        public void SetUp(WallData wallDatas)
        {
            for (int i = 0; i < wallDatas.shapes.Count; i++)
            {
                var shape = wallDatas.shapes[i];
                var wall = walls[i];
                wall.SetUp(shape);
            }
        }
    }
}