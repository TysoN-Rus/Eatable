using UnityEngine;

namespace Eatable
{
    public class GameMain : MonoBehaviour
    {

        [SerializeField] private CanvasContainer canvasContainer;
        [SerializeField] private Container container;
        [SerializeField] private SpawnerContainer spawnerContainer;


        private Timer timer;
        private Score score;
        private HeartControll heartControll;
        private SpawnCard spawnCard;
        private CardControll cardControll;
        private GameOverController gameOver;

        void Awake()
        {
            timer = new Timer(this, canvasContainer.SliderTime, container.PresetSetting.TimerSec);
            score = new Score(canvasContainer.Score, container.PresetSetting.MaxCountStar);
            heartControll = new HeartControll(container.PresetSetting.CountHeart, canvasContainer.PrefabHeart, canvasContainer.ParentHeart);
            gameOver = new GameOverController(canvasContainer, score);

            spawnCard = new SpawnCard(this, spawnerContainer);
            cardControll = new CardControll(container.AllCardInfo, spawnCard);
        }

        private void Start()
        {
            cardControll.Start();
        }
    }
}