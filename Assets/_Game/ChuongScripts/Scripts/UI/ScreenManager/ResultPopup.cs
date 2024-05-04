using UnityEngine;

namespace ChuongCustom
{
    public class ResultPopup : SimpleScreen
    {
        public override ScreenType GetID() => ScreenType.Result;
    }

    public class ResultModel
    {
        public bool isWin;
    }
}