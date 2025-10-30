using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace _0.Game.Scripts.Gameplay
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Game/LevelData", order = 0)]
    public class MapData : ScriptableObject
    {
        public List<WallData> walls;

#if UNITY_EDITOR
        [Button]
        public void RandomWall()
        {
            foreach (var a in walls)
            {
                for (int i = 0; i < a.shapes.Count; i++)
                {
                    var random = Random.Range(0, 3);
                    a.shapes[i] = (GameController.ShapeType)random; 
                }

            }

            EditorUtility.SetDirty(this); 
            AssetDatabase.SaveAssets();  
        }
#endif
    }
}