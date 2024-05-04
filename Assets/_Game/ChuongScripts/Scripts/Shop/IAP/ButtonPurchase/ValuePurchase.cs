using TMPro;
using UnityEngine;

namespace ChuongCustom
{
    public abstract class ValuePurchase : ButtonPurchase<IAPSingleValueData>
    {
        [SerializeField] private TextMeshProUGUI price;
        [SerializeField] private TextMeshProUGUI valueTMP;
        [SerializeField] protected int Value;

        protected override void SetupPurchaseData(IAPSingleValueData iapData)
        {
            price.SetText(iapData.price);
            valueTMP.SetText(Value.ToString() + "x");
        }
    }
}