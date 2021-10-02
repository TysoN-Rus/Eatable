using UnityEngine;

namespace Eatable
{
    public class Container : MonoBehaviour
    {
        [SerializeField] private CardInfo[] allCardInfo;
        [SerializeField] private PresetSetting presetSetting;

        public CardInfo[] AllCardInfo => allCardInfo;
        public PresetSetting PresetSetting => presetSetting;

    }
}