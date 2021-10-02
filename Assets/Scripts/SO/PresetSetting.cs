using UnityEngine;

namespace Eatable
{
    [CreateAssetMenu(fileName = "PresetSetting", menuName = "SO/PresetSetting")]
    public class PresetSetting : ScriptableObject
    {
        [SerializeReference] private int countHeart;
        [SerializeReference] private int maxCountStar;
        [SerializeReference] private int timerSec;

        public int CountHeart => countHeart;
        public int MaxCountStar => maxCountStar;
        public int TimerSec => timerSec;
    }
}