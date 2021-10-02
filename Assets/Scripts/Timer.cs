using EventBusSystem;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Eatable
{
    public class Timer : IResetTimer, IStopTimer, IGameOver
    {
        private MonoBehaviour mono;
        private Slider slider;
        private int maxTime;

        private IEnumerator coroutine;

        public Timer(MonoBehaviour mono, Slider slider, int maxTime)
        {
            this.mono = mono;
            this.slider = slider;
            this.maxTime = maxTime;
            EventBus.Subscribe(this);
            Reset();
        }

        private IEnumerator TikerSecond(float maxTimeSec)
        {
            while (true)
            {
                yield return null;
                maxTimeSec -= Time.deltaTime;
                slider.value = maxTimeSec / maxTime;
                if (maxTimeSec < 0)
                {
                    EventBus.RaiseEvent<ITimeOver>(x => x.TimeOver());
                    Stop();
                    break;
                }
            }
        }

        public void Reset()
        {
            if (coroutine == null)
            {
                coroutine = TikerSecond(maxTime);
                mono.StartCoroutine(coroutine);
            }
            else
            {
                mono.StopCoroutine(coroutine);
                coroutine = TikerSecond(maxTime);
                mono.StartCoroutine(coroutine);
            }
        }

        public void Stop()
        {
            if (coroutine != null)
            {
                mono.StopCoroutine(coroutine);
                coroutine = null;
            }
                
        }

        public void GameOver() => Stop();
    }
}