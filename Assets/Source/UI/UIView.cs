using Cinemachine;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIView : MonoBehaviour
{
    [Header("Camera Offsets")]
    public Vector3 startCameraOffset;
    public Vector3 gameCameraOffset;

    [Header("Panels Elements")]
    public Image handImage;
    public TMP_Text textInstruction;
    public TMP_Text coinsText;
    public Slider progressSlider;

    [Header("Game Panels")]
    public GameObject menuPanel;
    public GameObject startPanel;
    public GameObject gamePanel;
    public GameObject pausePanel;
    public GameObject losePanel;
    public GameObject winPanel;

    [Header("Coin Manager")]
    public CoinManager coinManager;

    [Header("Coin Manager")]
    public CarDriveProgress carDriveProgress;

    [HideInInspector] public CinemachineTransposer transposer;
    [HideInInspector] public CinemachineVirtualCamera virtualCamera;

    [HideInInspector] public Tweener handTween;
    [HideInInspector] public Tweener instructionTextTween;

    [HideInInspector][Inject] public Camera playerCamera;
    [HideInInspector][Inject] public GameManager gameManager;
}
