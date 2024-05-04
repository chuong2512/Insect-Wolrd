using UnityEngine;

namespace ChuongCustom
{
    public class BuySubIAP : ValuePurchase
    {
        protected override void Setup()
        {
        }

        protected override void OnPurchaseSuccess()
        {
            ToastManager.Instance.ShowMessageToast("Buy Success!!");
            Data.Player.time += Value;
        }

        private void AddTime(int time)
        {
            GameAction.SetRegisterTime.Invoke(time);
        }
    }
}