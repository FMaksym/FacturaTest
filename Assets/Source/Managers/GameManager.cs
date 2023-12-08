using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void StartGameEventHandler();
    public static event StartGameEventHandler StartGame;

    [SerializeField] private bool _IsGame;

    private void OnEnable()
    {
        CarHealth.CarDie += GameOver;
    }

    public void StartLevel()
    {
        _IsGame = true;
        StartGame?.Invoke();
    }

    public void GameOver()
    {
        _IsGame = false;
    }

    public void PauseGame()
    {
        _IsGame = false;
        Time.timeScale = 0;
    }

    public void ResumeGame() 
    { 
        _IsGame = true;
        Time.timeScale = 1;
    }

    public bool IsGame() => _IsGame;

    private void OnDisable()
    {
        CarHealth.CarDie -= GameOver;
    }
}
