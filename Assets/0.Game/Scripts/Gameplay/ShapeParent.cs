using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _0.Game.Scripts.Gameplay
{
    public class ShapeParent : MonoBehaviour
    {
        public List<Shape> shapes;

        public void Move()
        {
            StartCoroutine(MoveIE());
        }

        private IEnumerator MoveIE()
        {
            for (int i = 0; i < shapes.Count; i++)
            {
                var obj = shapes[i];
                obj.ReadyMove();
            }

            yield return new WaitForSeconds(1f);
            for (int i = 0; i < shapes.Count; i++)
            {
                var obj = shapes[i];
                var endPos = new Vector3(GameController.instance.endPos.position.x,
                    obj.transform.position.y ,GameController.instance.endPos.position.z);
                Common.Scripts.Common.TweenMoveVelocity(obj.transform, endPos, 0.45f,
                    false);
            }
            
        }
    }
}