using _0.Common.Scripts;
using UnityEngine;

namespace _0.Game.Scripts.Gameplay
{
    public class ButtonShape : MonoBehaviour
    {
        public GameController.ShapeType shape;

        public void OnClick()
        {
            AudioManager.instance?.PlayButtonClick();
            GameController.instance.ChangeShape(shape);
        }
    }
}