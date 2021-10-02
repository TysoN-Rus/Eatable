using EventBusSystem;
using TMPro;

namespace Eatable
{
    public class Score : IGoodSelect, IResetGame
    {
        private TMP_Text scoreText;
        private int maxScore;
        private int nowScore;

        public Score(TMP_Text scoreText, int maxScore)
        {
            this.scoreText = scoreText;
            this.maxScore = maxScore;
            EventBus.Subscribe(this);
            UpdateText();
        }

        public void GoodSelect()
        {
            if (nowScore < maxScore)
            {
                nowScore++;
                UpdateText();
            }
        }

        public void Reset()
        {
            nowScore = 0;
            UpdateText();
        }

        private void UpdateText()
        {
            scoreText.text = nowScore.ToString("0");
        }
        public int GetScore() => nowScore;

    }
}