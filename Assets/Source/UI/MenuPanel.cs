using Cinemachine;
using UnityEngine;
using Zenject;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private Vector3 _startCameraOffset;
    [SerializeField] private Vector3 _gameCameraOffset;
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _startPanel;

    private CinemachineTransposer _transposer;
    private CinemachineVirtualCamera _virtualCamera;

    [Inject] private Camera _playerCamera;

    private void Awake()
    {
        _virtualCamera = _playerCamera.GetComponent<Cinemachine.CinemachineVirtualCamera>();
        _transposer = _virtualCamera.GetCinemachineComponent<CinemachineTransposer>();

        if (_transposer != null)
        {
            _transposer.m_FollowOffset = _startCameraOffset;
        }
    }

    public void OnClickPlay()
    {
        ChangeCinemachineOffset();
        _menuPanel.SetActive(false);
        _startPanel.SetActive(true);
    }

    private void ChangeCinemachineOffset()
    {

        if (_transposer != null)
        {
            _transposer.m_FollowOffset = _gameCameraOffset;
        }
    }
}
