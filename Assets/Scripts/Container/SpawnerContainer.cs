using UnityEngine;

public class SpawnerContainer : MonoBehaviour
{
    [SerializeField] private Card prefCard;
    [SerializeField] private Transform parentCard;
    [SerializeField] private MagicCircle magicCircle;

    public Card PrefCard => prefCard;
    public Transform ParentCard => parentCard;
    public MagicCircle MagicCircle => magicCircle;
}
