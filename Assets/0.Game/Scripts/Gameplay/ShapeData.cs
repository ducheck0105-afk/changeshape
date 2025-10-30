using System;
using System.Collections.Generic;

namespace _0.Game.Scripts.Gameplay
{
    [Serializable]
    public class WaveData
    {
        public List<ShapeData> shapeInWaves;
    }
    [Serializable]
    public class ShapeData
    {
        public List<GameController.ShapeType> shapes;
    }
}