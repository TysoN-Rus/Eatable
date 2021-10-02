using EventBusSystem;
using System.Collections.Generic;
using UnityEngine;

namespace Eatable
{
    public class SpawnCard : IGameOver
    {
        private MonoBehaviour mono;
        private Card prefCard;
        private Transform parentCard;
        private MagicCircle magicCircle;

        private Card activeCard;

        public void SpawnNewCard(CardInfo cardInfo)
        {
            if (activeCard)
            {
                activeCard.transform.parent = mono.transform;
                activeCard.animator.SetTrigger("Down");
            }
            activeCard = GetCard();
            activeCard.icon.sprite = cardInfo.Icon;
            activeCard.text.text = cardInfo.Text;
            magicCircle.PlayAnima();
        }

        List<Card> cardPool;

        public SpawnCard(MonoBehaviour mono, SpawnerContainer spawnerContainer)
        {
            this.mono = mono;
            prefCard = spawnerContainer.PrefCard;
            parentCard = spawnerContainer.ParentCard;
            magicCircle = spawnerContainer.MagicCircle;

            cardPool = new List<Card>();
            EventBus.Subscribe(this);
        }

        private Card GetCard()
        {
            for (int i = 0; i < cardPool.Count; i++)
            {
                if (!cardPool[i].gameObject.activeSelf)
                {
                    cardPool[i].transform.parent = parentCard;
                    cardPool[i].transform.localPosition = Vector3.zero;
                    cardPool[i].transform.localEulerAngles = Vector3.zero;
                    cardPool[i].gameObject.SetActive(true);
                    return cardPool[i];
                }
            }
            Card temp = GameObject.Instantiate(prefCard, parentCard);
            cardPool.Add(temp);
            return temp;
        }

        public void GameOver()
        {
            if (activeCard)
            {
                activeCard.transform.parent = mono.transform;
                activeCard.animator.SetTrigger("Down");
                activeCard = null;
            }
        }
    }
}