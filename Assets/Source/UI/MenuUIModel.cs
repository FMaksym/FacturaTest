using Cinemachine;
using DG.Tweening;
using UnityEngine;

public class MenuUIModel : MonoBehaviour
{
    public void GetCinemachineCamera(UIView view)
    {
        view.virtualCamera = view.playerCamera.GetComponent<CinemachineVirtualCamera>();
        view.transposer = view.virtualCamera.GetCinemachineComponent<CinemachineTransposer>();

        if (view.transposer != null)
        {
            view.transposer.m_FollowOffset = view.startCameraOffset;
        }
    }

    private void ChangeCinemachineOffset(UIView view)
    {

        if (view.transposer != null)
        {
            view.transposer.m_FollowOffset = view.gameCameraOffset;
        }
    }

    public void PlayGame(UIView view)
    {
        ChangeCinemachineOffset(view);
        view.menuPanel.SetActive(false);
        view.startPanel.SetActive(true);
    }

    public void StartGame(UIView view)
    {
        view.startPanel.SetActive(false);
        view.gamePanel.SetActive(true);
        view.gameManager.StartLevel();
    }

    public void StartInstructionTweens(UIView view)
    {
        view.handTween = view.handImage.transform.DOLocalMoveX(300f, 1f).SetLoops(10000, LoopType.Yoyo).SetEase(Ease.InOutSine);
        view.instructionTextTween = view.textInstruction.transform.DOScale(1.2f, 0.8f).SetLoops(10000, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    public void KillInstructionTweens(UIView view)
    {
        view.handTween.Kill();
        view.instructionTextTween.Kill();
    }
}
