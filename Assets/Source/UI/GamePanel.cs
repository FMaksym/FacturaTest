using UnityEngine;
using Zenject;

public class GamePanel : MonoBehaviour
{
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _pausePanel;

    [Inject] private GameManager _gameManager;

    public void Pause()
    {
        _gamePanel.SetActive(false);
        _pausePanel.SetActive(true);
        _gameManager.PauseGame();
    }
}
