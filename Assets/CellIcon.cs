using System.Collections;
using System.Collections.Generic;
using ChuongCustom;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class CellIcon : AButton
{
    public Sprite[] Sprites;

    public GameObject GameObject;
    public Image icon;

    public CellData data;
    public bool canChoose = true;
    public bool IsActive => GameObject.activeSelf;

    public void SetID(CellData CellData)
    {
        this.data = CellData;
        icon.sprite = Sprites[CellData.ID];
        icon.SetNativeSize();
    }

    public void SetActive(bool b)
    {
        GameObject.SetActive(b);
    }

    protected override void OnClickButton()
    {
        if (canChoose)
        {
            canChoose = false;
            AnswerCell.Instance.AddID(data);
            SetActive(false);
        }
    }

    public void Choose()
    {
        OnClickButton();
    }

    protected override void OnStart()
    {
    }
}