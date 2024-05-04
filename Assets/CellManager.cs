using System.Collections.Generic;
using System.Linq;
using ChuongCustom;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

public class CellManager : Singleton<CellManager>
{
    public CellIcon[] CellIcons;

    public AnswerCell AnswerCell;

    private void OnValidate()
    {
        CellIcons = GetComponentsInChildren<CellIcon>();
    }

    public void Start()
    {
        RandomCell();

        AnswerCell.Instance.Init();
    }

    private void RandomCell()
    {
        List<int> ids = new List<int>();

        for (int i = 0; i < 24; i++)
        {
            var rand = Random.Range(0, 11);

            ids.Add(rand);
            ids.Add(rand);
            ids.Add(rand);
        }

        Shuffle(ids);

        for (int i = 0; i < CellIcons.Length; i++)
        {
            CellIcons[i].SetID(new CellData()
            {
                MapID = i,
                ID = ids[i]
            });

            CellIcons[i].canChoose = true;
        }
    }

    public void Back()
    {
        int mapID = AnswerCell.Instance.Back();

        if (mapID < 0)
        {
            return;
        }

        var icon = CellIcons.ToList().Find(cellIcon => cellIcon.data.MapID == mapID);
        icon.SetActive(true);
        icon.canChoose = true;
    }

    public void Magnet()
    {
        var result = CellIcons.ToList().GroupBy(x => x.data.ID)
            .Where(g => g.Count() > 2)
            .Select(x => x.Key)
            .ToList();

        var id = -1;

        for (int i = 0; i < result.Count; i++)
        {
            var icon = CellIcons.ToList().Find(cellIcon => cellIcon.canChoose && cellIcon.data.ID == result[i]);

            if (icon != null)
            {
                id = icon.data.ID;
                break;
            }
        }

        if (id < 0)
        {
            return;
        }

        if (result is {Count: > 0})
        {
            for (int i = 0; i < 3; i++)
            {
                var icon = CellIcons.ToList().Find(cellIcon => cellIcon.canChoose && cellIcon.data.ID == id);
                icon.Choose();
            }
        }
    }

    public void Shuffle<T>(IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }
    }

    public void CheckWin()
    {
        for (int i = 0; i < CellIcons.Length; i++)
        {
            if (CellIcons[i].canChoose)
            {
                return;
            }
        }

        Manager.InGame.Win();
    }
}