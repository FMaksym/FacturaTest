using UnityEngine;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _losePanel;

    private void OnEnable()
    {
        CarHealth.CarDie += ActivateLosePanel;
    }

    private void ActivateLosePanel()
    {
        _gamePanel.gameObject.SetActive(false);
        _losePanel.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        CarHealth.CarDie -= ActivateLosePanel;
    }
}
