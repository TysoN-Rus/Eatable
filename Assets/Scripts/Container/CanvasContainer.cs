using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasContainer : MonoBehaviour
{
    [Header("Time")]
    [SerializeField] private Slider sliderTime;

    [Header("Live")]
    [SerializeField] private Transform parentHeart;
    [SerializeField] private Image prefabHeart;

    [Header("Score")]
    [SerializeField] private TMP_Text score;

    [Header("GameOver")]
    [SerializeField] private GameObject gameOverWindow;
    [SerializeField] private Button newGame;
    [SerializeField] private TMP_Text finalAccount;

    public Slider SliderTime => sliderTime;
    public Transform ParentHeart => parentHeart;
    public Image PrefabHeart => prefabHeart;
    public TMP_Text Score => score;
    public GameObject GameOverWindow => gameOverWindow;
    public Button NewGame => newGame;
    public TMP_Text FinalAccount => finalAccount;
}

