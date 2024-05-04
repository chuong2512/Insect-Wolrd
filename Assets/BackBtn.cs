using System.Collections;
using System.Collections.Generic;
using ChuongCustom;
using UnityEngine;

public class BackBtn : AShopBtn
{
    protected override void ShowNotEnoughMoney()
    {
        ToastManager.Instance.ShowMessageToast("Not enough Back skill!!");
    }

    protected override bool IsEnoughResource()
    {
        return Data.Player.Gem >= 1;
    }

    protected override void OnBuySuccess()
    {
        Data.Player.Gem -= 1;
        ToastManager.Instance.ShowMessageToast("Buy Success!!");
        //todo:
        CellManager.Instance.Back();
    }

    protected override void OnStart()
    {
    }
}