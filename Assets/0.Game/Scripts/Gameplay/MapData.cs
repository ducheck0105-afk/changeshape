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
        public List<WaveData> waves;

#if UNITY_EDITOR
        [Button]
        public void RandomWall()
        {
            foreach (var a in waves)
            {
                foreach (var b in a.shapeInWaves)
                {
                    for (int i = 0; i < b.shapes.Count; i++)
                    {
                        var random = Random.Range(0, 6);
                        b.shapes[i] = (GameController.ShapeType)random; 
                    }
                }
            
            }

            EditorUtility.SetDirty(this); 
            AssetDatabase.SaveAssets();  
        }
#endif
    }
}