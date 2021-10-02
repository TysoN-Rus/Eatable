using UnityEngine;

public class MagicCircle : MonoBehaviour
{
    private Animator anim;
    private void Awake() => anim = GetComponent<Animator>();
    public void PlayAnima() => anim.SetTrigger("Magic");
}
