using System;
using System.Collections.Generic;
using System.Linq;
using ChuongCustom;
using UnityEngine;

namespace DefaultNamespace
{
    public class AnswerCell : Singleton<AnswerCell>
    {
        public List<int> history;

        public List<CellData> listID;

        public CellIcon[] CellIcons;

        public List<CellData> ListID
        {
            get => listID;
            set => listID = value;
        }

        private void OnValidate()
        {
            CellIcons = GetComponentsInChildren<CellIcon>();
        }

        public void Init()
        {
            ListID = new List<CellData>();
            history = new List<int>();
            Refresh();
        }

        public void AddID(CellData data)
        {
            if (!CheckMatch(data))
            {
                ListID.Add(data);
                history.Add(data.MapID);
                Refresh();
            }
        }

        private bool CheckMatch(CellData data)
        {
            var dataSameID = ListID.FindAll(cellData => cellData.ID == data.ID);

            if (dataSameID is {Count: >= 2})
            {
                for (int i = 0; i < dataSameID.Count; i++)
                {
                    history.Remove(dataSameID[i].MapID);
                    ListID.RemoveAll(cellData => cellData.ID == data.ID);
                }

                Refresh();

                return true;
            }

            return false;
        }

        private void Refresh()
        {
            listID.Sort((x, y) => x.ID - y.ID);

            if (history.Count >= 7)
            {
                Manager.InGame.Lose();
                return;
            }

            CellManager.Instance.CheckWin();

            for (int i = 0; i < CellIcons.Length; i++)
            {
                CellIcons[i].canChoose = false;

                if (i >= listID.Count)
                {
                    CellIcons[i].SetActive(false);
                }
                else
                {
                    CellIcons[i].SetActive(true);
                    CellIcons[i].SetID(listID[i]);
                }
            }
        }

        public int Back()
        {
            if (history.Count == 0)
            {
                return -1;
            }

            var lastMapID = history[^1];

            history.Remove(lastMapID);
            ListID.RemoveAll(cellData => cellData.MapID == lastMapID);
            Refresh();

            return lastMapID;
        }
    }

    [Serializable]
    public class CellData
    {
        public int ID;
        public int MapID;
    }
}