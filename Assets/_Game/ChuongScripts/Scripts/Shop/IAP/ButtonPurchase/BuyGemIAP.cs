using TMPro;
using UnityEngine;

namespace ChuongCustom
{
    public class BuyGemIAP : ValuePurchase
    {
        [SerializeField] private TextMeshProUGUI value1TMP;
        [SerializeField] private int Value1;

        protected override void Setup()
        {
            value1TMP.SetText(Value1.ToString() +"x");
        }

        protected override void OnPurchaseSuccess()
        {
            ToastManager.Instance.ShowMessageToast("Buy Success!!");
            Data.Player.Gem += Value;
            Data.Player.Coin += Value1;
        }
    }
}