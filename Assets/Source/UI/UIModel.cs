using UnityEngine;

public class UIModel : MonoBehaviour
{
    public MenuUIModel menuModel;
    public GameUIModel gameModel;
    public EndGameUIModel endGameModel;

    public void RefreshCoinText(UIView view)
    {
        view.coinsText.text = view.coinManager.GetCoins().ToString();
    }
}
