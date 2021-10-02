using EventBusSystem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Eatable
{
    public class HeartControll : IFailSelect, IResetGame
    {
        private int heartCount;
        private List<Image> heards;

        public HeartControll(int maxHeartCount, Image prefabHeart, Transform parentHeart)
        {
            EventBus.Subscribe(this);
            heards = new List<Image>();
            heartCount = maxHeartCount;
            for (int i = 0; i < heartCount; i++)
                heards.Add(GameObject.Instantiate(prefabHeart, parentHeart));
        }

        public void FailSelect()
        {
            heards[heartCount - 1].color -= Color.black * 0.5f;
            heartCount--;
            if (heartCount <= 0)
            {
                EventBus.RaiseEvent<IStopTimer>(x => x.Stop());
                EventBus.RaiseEvent<IGameOver>(x => x.GameOver());
            }
        }

        public void Reset()
        {
            for (int i = 0; i < heards.Count; i++) heards[i].color += Color.black * 0.5f;
            heartCount = heards.Count;
        }

    }
}