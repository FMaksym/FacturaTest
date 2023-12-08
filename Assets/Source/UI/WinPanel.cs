using UnityEngine;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _winPanel;

    private void OnEnable()
    {
        FinishGameControl.FinishGame += ActivateWinPanel;
    }

    private void ActivateWinPanel()
    {
        _gamePanel.gameObject.SetActive(false);
        _winPanel.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        FinishGameControl.FinishGame -= ActivateWinPanel;
    }
}
