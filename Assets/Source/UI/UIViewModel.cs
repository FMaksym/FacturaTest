using UnityEngine;

public class UIViewModel : MonoBehaviour
{
    [SerializeField] private UIView _viewUI;
    [SerializeField] private UIModel _modelUI;

    private void OnEnable()
    {
        CoinManager.AddCoin += CoinAdd;
        CarHealth.CarDie += PlayerLose;
        FinishGameControl.FinishGame += PlayerWin;
    }

    private void Awake()
    {
        _modelUI.menuModel.GetCinemachineCamera(_viewUI);
    }

    private void Start()
    {
        _modelUI.RefreshCoinText(_viewUI);
    }

    private void FixedUpdate()
    {
        if (_viewUI.gameManager.IsGame())
        {
            _modelUI.gameModel.ChangeProgressOnSlider(_viewUI);
        }
    }

    public void OnClickReadyToPlay()
    {
        _modelUI.menuModel.PlayGame(_viewUI);
        _modelUI.menuModel.StartInstructionTweens(_viewUI);
    }

    public void OnClickStartGame()
    {
        _modelUI.menuModel.StartGame(_viewUI);
        _modelUI.menuModel.KillInstructionTweens(_viewUI);
    }

    public void OnClickPauseGame() 
    {
        _modelUI.gameModel.PauseGame(_viewUI);
    }

    public void OnClickResumeGame()
    {
        _modelUI.gameModel.ResumeGame(_viewUI);
    }
    public void OnClickInMenu()
    {
        _modelUI.gameModel.InMenu();
    }

    private void PlayerWin()
    {
        _modelUI.endGameModel.ActivateWinPanel(_viewUI);
    }

    private void PlayerLose()
    {
        _modelUI.endGameModel.ActivateLosePanel(_viewUI);
    }

    private void CoinAdd()
    {
        _modelUI.RefreshCoinText(_viewUI);
    }

    private void OnDisable()
    {
        CoinManager.AddCoin -= CoinAdd;
        CarHealth.CarDie -= PlayerLose;
        FinishGameControl.FinishGame -= PlayerWin;
    }
}
