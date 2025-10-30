using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace _0.Common.Scripts
{
    public static class Common

    {
        public static void ShowPopup(this Transform obj)
        {
            obj.transform.localScale = Vector3.one * 0.5f;
            obj.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetUpdate(true);
        }

        public static float GetPercent(float currentValue, float maxValue)
        {
            if (maxValue <= 0f)
                return 0f;

            return Mathf.Clamp01(currentValue / maxValue);
        }

        public static float GetPercent100(float currentValue, float maxValue)
        {
            if (maxValue <= 0f)
                return 0f;

            return Mathf.Clamp(currentValue / maxValue * 100f, 0f, 100f);
        }

        public static bool RandomBool()
        {
            return UnityEngine.Random.value < 0.5f;
        }

        public static bool RandomByPercent(float percent)
        {
            return UnityEngine.Random.Range(0f, 100f) < percent;
        }


        public static string GetLevelName(int level)
        {
            var lv = 0;
            if (level >= 8) lv = Random.Range(4, 8);
            else lv = level;
            return $"Level_{lv}";
        }

        #region Tween

        public static Tweener TweenMoveTime(Transform trans, Vector3 to, float duration
            , bool isLocal = true, bool isUsingUnscaleTime = false)
        {
            var tween = isLocal ? trans.DOLocalMove(to, duration) : trans.DOMove(to, duration);
            return tween.SetUpdate(isUsingUnscaleTime);
        }

        public static Tweener TweenMoveTime(Transform trans, Vector3 start, Vector3 to, float duration
            , bool isLocal = true, bool isUsingUnscaleTime = false)
        {
            if (isLocal)
                trans.localPosition = start;
            else
                trans.position = start;

            return TweenMoveTime(trans, to, duration, isLocal, isUsingUnscaleTime);
        }

        public static Tweener TweenMoveVelocity(Transform trans, Vector3 to, float velocity
            , bool isLocal = true, bool isUsingUnscaleTime = false)
        {
            var duration = Vector3.Distance(isLocal ? trans.localPosition : trans.position, to) / velocity;
            return TweenMoveTime(trans, to, duration, isLocal, isUsingUnscaleTime);
        }

        public static Tweener TweenMoveVelocity(Transform trans, Vector3 start, Vector3 to, float velocity
            , bool isLocal = true, bool isUsingUnscaleTime = false)
        {
            if (isLocal)
                trans.transform.localPosition = start;
            else
                trans.transform.position = start;

            return TweenMoveVelocity(trans, to, velocity, isLocal, isUsingUnscaleTime);
        }

        public static Tweener TweenMoveVelocityX(Transform trans, float to, float velocity
            , bool isLocal = true, bool isUsingUnscaleTime = false)
        {
            var duration = Mathf.Abs((isLocal ? trans.localPosition.x : trans.position.x) - to) / velocity;
            var tween = isLocal ? trans.DOLocalMoveX(to, duration) : trans.DOMoveX(to, duration);
            return tween.SetUpdate(isUsingUnscaleTime);
        }
        public static Tweener TweenMoveVelocityZ(Transform trans, float to, float velocity
            , bool isLocal = true, bool isUsingUnscaleTime = false)
        {
            var duration = Mathf.Abs((isLocal ? trans.localPosition.x : trans.position.x) - to) / velocity;
            var tween = isLocal ? trans.DOLocalMoveX(to, duration) : trans.DOMoveX(to, duration);
            return tween.SetUpdate(isUsingUnscaleTime);
        }
        public static Tweener TweenMoveVelocityX(Transform trans, float start, float to, float velocity
            , bool isLocal = true, bool isUsingUnscaleTime = false)
        {
            Vector3 currentPos;
            if (isLocal)
            {
                currentPos = trans.transform.localPosition;
                trans.transform.localPosition = new Vector3(start, currentPos.y, currentPos.z);
            }
            else
            {
                currentPos = trans.transform.position;
                trans.transform.position = new Vector3(start, currentPos.y, currentPos.z);
            }

            return TweenMoveVelocityX(trans, to, velocity, isLocal, isUsingUnscaleTime);
        }

        public static Tweener TweenMoveVelocityY(Transform trans, float to, float velocity
            , bool isLocal = true, bool isUsingUnscaleTime = false)
        {
            var duration = Mathf.Abs((isLocal ? trans.localPosition.y : trans.position.y) - to) / velocity;
            var tween = isLocal ? trans.DOLocalMoveY(to, duration) : trans.DOMoveY(to, duration);
            return tween.SetUpdate(isUsingUnscaleTime);
        }

        public static Tweener TweenMoveVelocityY(Transform trans, float start, float to, float velocity
            , bool isLocal = true, bool isUsingUnscaleTime = false)
        {
            Vector3 currentPos;
            if (isLocal)
            {
                currentPos = trans.transform.localPosition;
                trans.transform.localPosition = new Vector3(currentPos.x, start, currentPos.z);
            }
            else
            {
                currentPos = trans.transform.position;
                trans.transform.position = new Vector3(currentPos.x, start, currentPos.z);
            }

            return TweenMoveVelocityY(trans, to, velocity, isLocal, isUsingUnscaleTime);
        }

        #endregion
    }
}