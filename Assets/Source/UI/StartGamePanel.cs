using DG.Tweening;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Zenject;

public class StartGamePanel : MonoBehaviour
{
    [SerializeField] private Image _handImage;
    [SerializeField] private TMP_Text _textInstruction;
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _gamePanel;

    [Inject] private GameManager _gameManager;

    private void Start()
    {
        _handImage.transform.DOLocalMoveX(300f, 1f).SetLoops(10000, LoopType.Yoyo).SetEase(Ease.InOutSine);
        _textInstruction.transform.DOScale(1.2f, 0.8f).SetLoops(10000, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    public void StartGame()
    {
        _startPanel.SetActive(false);
        _gamePanel.SetActive(true);
        _gameManager.StartLevel();
    }
}
