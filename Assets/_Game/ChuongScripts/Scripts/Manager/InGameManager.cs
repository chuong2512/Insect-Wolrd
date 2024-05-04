using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace ChuongCustom
{
    public class InGameManager : Singleton<InGameManager>
    {
        [SerializeField] public int PriceToPrice = 1;

        public int CurrentLevel
        {
            get => Data.Player.level;
            private set => Data.Player.level = value;
        }

        private void Start()
        {
            ScoreManager.Reset();
        }

        [Button]
        public void Win()
        {
            CurrentLevel++;
            Manager.ScreenManager.OpenScreen(ScreenType.Result);
            //todo:
        }

        [Button]
        public void Lose()
        {
            Manager.ScreenManager.OpenScreen(ScreenType.Lose);
            //todo:
        }

        [Button]
        public void BeforeLose()
        {
            Manager.ScreenManager.OpenScreen(ScreenType.BeforeLose);
            //todo:
        }

        public void Retry()
        {
            //retry
            SceneManager.LoadScene("GameScene");
        }

        public void Continue()
        {
            //continue
            CurrentLevel++;
            SceneManager.LoadScene("GameScene");
        }
    }
}