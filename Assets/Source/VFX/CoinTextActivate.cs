using TMPro;
using UnityEngine;

public class CoinTextActivate : TextActivate
{
    [SerializeField] private int _index;
    [SerializeField] private TMP_Text[] _text;
    [SerializeField] private CoinManager _coinManager;

    public void ActivateText(Transform textTransform, int coinValue)
    {
        _coinManager.AddCoins(coinValue);
        base.SetCoinText(_text, _index, coinValue);
        _text[_index].gameObject.SetActive(true);
        _text[_index].transform.position = textTransform.position + new Vector3(0, 3, 0);
    }
}
