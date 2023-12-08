using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public delegate void AddCoinEventHandler();
    public static event AddCoinEventHandler AddCoin;

    private const string CoinKey = "PlayerCoins";
    private int _currentCoins;

    private void Start()
    {
        LoadCoins();
    }

    private void LoadCoins()
    {
        _currentCoins = PlayerPrefs.GetInt(CoinKey, 0);
    }

    public void AddCoins(int amount)
    {
        _currentCoins += amount;
        AddCoin?.Invoke();
        SaveCoins();
    }

    public int GetCoins()
    {
        return _currentCoins;
    }

    private void SaveCoins()
    {
        PlayerPrefs.SetInt(CoinKey, _currentCoins);
        PlayerPrefs.Save();
    }
}
