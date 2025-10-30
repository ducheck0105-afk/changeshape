using System.Collections.Generic;
using UnityEngine;

namespace _0.Game.Scripts.Gameplay
{
    public class WallObject : MonoBehaviour
    {
        public List<WallGroup> wallGroups;
        private WallGroup currentWallGroup;

        public void SetUp(WallData wallData)
        {
            var group = wallGroups[wallData.shapes.Count-1];
            group.SetUp(wallData);
            group.gameObject.SetActive(true);
        }
    }
}