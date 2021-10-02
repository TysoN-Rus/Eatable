using EventBusSystem;
using TMPro;
using UnityEngine;

namespace Eatable
{
    public class GameOverController : IGameOver
    {
        private GameObject panel;
        private TMP_Text scoreText;
        private Score score;

        public GameOverController(CanvasContainer canvas, Score score)
        {
            panel = canvas.GameOverWindow;
            this.score = score;
            scoreText = canvas.FinalAccount;
            canvas.NewGame.onClick.AddListener(NewGame);
            EventBus.Subscribe(this);
        }

        public void GameOver()
        {
            panel.SetActive(true);
            scoreText.text = score.GetScore().ToString("0");
        }
        private void NewGame()
        {
            EventBus.RaiseEvent<IResetGame>(x => x.Reset());
            panel.SetActive(false);
        }
    }
}