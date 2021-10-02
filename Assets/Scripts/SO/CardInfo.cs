using UnityEngine;

namespace Eatable
{
    [CreateAssetMenu(fileName = "CardInfo", menuName = "SO/CardInfo")]
    public class CardInfo : ScriptableObject
    {
        [SerializeReference] private Sprite icon;
        [SerializeReference] private string text;
        [SerializeReference] private DirectionSelection goodDirection;

        public Sprite Icon => icon;
        public string Text => text;
        public DirectionSelection GoodDirection => goodDirection;
    }
}