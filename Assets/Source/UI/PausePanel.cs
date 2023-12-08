using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _pausePanel;

    [Inject] private GameManager _gameManager;

    public void Resume()
    {
        _pausePanel.SetActive(false);
        _gamePanel.SetActive(true);
        _gameManager.ResumeGame();
    }

    public void InMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
