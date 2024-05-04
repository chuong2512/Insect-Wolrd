using System.Collections;
using System.Collections.Generic;
using ChuongCustom;
using UnityEngine;

public class MagnetBtn : AShopBtn
{
    protected override void ShowNotEnoughMoney()
    {
        ToastManager.Instance.ShowMessageToast("Not enough magnet!!");
    }

    protected override bool IsEnoughResource()
    {
        return Data.Player.Coin >= 1;
    }

    protected override void OnBuySuccess()
    {
        Data.Player.Coin -= 1;
        ToastManager.Instance.ShowMessageToast("Buy Success!!");
        //todo:

        CellManager.Instance.Magnet();
    }

    protected override void OnStart()
    {
    }
}