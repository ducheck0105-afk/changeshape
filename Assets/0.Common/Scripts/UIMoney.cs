using TMPro;
using UnityEngine;

namespace _0.Common.Scripts
{
    public class UIMoney : MonoBehaviour
    {
        public TextMeshProUGUI moneyText;

        private void Start()
        {
            PlayerData.onChangeCoin += SetMoneyText;
            SetMoneyText();
        }

        private void OnDestroy()
        {
            PlayerData.onChangeCoin -= SetMoneyText;
        }

        private void SetMoneyText()
        {
            moneyText.text = PlayerData.currentGold.ToString();
        }
    }
}