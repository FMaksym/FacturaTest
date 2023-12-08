using TMPro;
using UnityEngine;

public class CoinPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsText;
    [SerializeField] private CoinManager _coinManager;

    private void OnEnable()
    {
        CoinManager.AddCoin += RefreshCoinText;
    }

    private void Awake()
    {
        RefreshCoinText();
    }

    private void RefreshCoinText()
    {
        _coinsText.text = _coinManager.GetCoins().ToString();
    }

    private void OnDisable()
    {
        CoinManager.AddCoin -= RefreshCoinText;
    }
}
