using EventBusSystem;
using Random = UnityEngine.Random;

namespace Eatable
{
    public class CardControll : ILeft, IRight, ITimeOver, IGameOver, IResetGame
    {
        private CardInfo[] allCardInfo;
        private SpawnCard spawnCard;

        private CardInfo activeCard;
        private bool isGame;

        public CardControll(CardInfo[] allCardInfo, SpawnCard spawnCard)
        {
            this.allCardInfo = allCardInfo;
            this.spawnCard = spawnCard;
            isGame = true;
            EventBus.Subscribe(this);
        }

        public void Start() => NextCard();

        public void Left() => ChecedDirection(DirectionSelection.Left);

        public void Right() => ChecedDirection(DirectionSelection.Right);

        private void ChecedDirection(DirectionSelection direction)
        {
            if (activeCard.GoodDirection == direction)
                EventBus.RaiseEvent<IGoodSelect>(x => x.GoodSelect());
            else
                EventBus.RaiseEvent<IFailSelect>(x => x.FailSelect());

            NextCard();
        }


        private CardInfo GetRandomCard() => allCardInfo[Random.Range(0, allCardInfo.Length)];

        public void TimeOver()
        {
            EventBus.RaiseEvent<IFailSelect>(x => x.FailSelect());
            NextCard();
        }
        private void NextCard()
        {
            if (!isGame) return;
            activeCard = GetRandomCard();
            spawnCard.SpawnNewCard(activeCard);
            EventBus.RaiseEvent<IResetTimer>(x => x.Reset());
        }

        public void GameOver() => isGame = false;

        public void Reset()
        {
            isGame = true;
            NextCard();
        }
    }
}