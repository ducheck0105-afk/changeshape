using System;
using UnityEngine;

namespace _0.Common.Scripts.BaseCore
{
    public class GameControllerBase : MonoBehaviour
    {
        public bool gameOver = true;
        public virtual void GameOver(bool result)
        {
            gameOver = true;
        }
    }
}