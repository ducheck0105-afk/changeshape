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
    }
}