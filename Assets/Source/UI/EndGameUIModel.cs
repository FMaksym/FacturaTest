using UnityEngine;

public class EndGameUIModel : MonoBehaviour
{
    public void ActivateLosePanel(UIView view)
    {
        view.gamePanel.SetActive(false);
        view.losePanel.SetActive(true);
    }

    public void ActivateWinPanel(UIView view)
    {
        view.gamePanel.SetActive(false);
        view.winPanel.SetActive(true);
    }
}
