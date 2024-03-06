using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIModel : MonoBehaviour
{
    public void ChangeProgressOnSlider(UIView view)
    {
        if (view.progressSlider != null)
        {
            view.progressSlider.value = view.carDriveProgress.GameProgress;
        }
    }

    public void PauseGame(UIView view)
    {
        view.gamePanel.SetActive(false);
        view.pausePanel.SetActive(true);
        view.gameManager.PauseGame();
    }

    public void ResumeGame(UIView view)
    {
        view.pausePanel.SetActive(false);
        view.gamePanel.SetActive(true);
        view.gameManager.ResumeGame();
    }

    public void InMenu()
    {
        Time.timeScale = 1;
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
