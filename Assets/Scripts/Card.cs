using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    public SpriteRenderer icon;
    public TMP_Text text;
    public Animator animator;

    public void SwitchOff() => gameObject.SetActive(false);
}
