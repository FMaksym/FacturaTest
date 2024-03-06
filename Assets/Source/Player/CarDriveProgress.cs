using UnityEngine;
using Zenject;

public class CarDriveProgress : MonoBehaviour
{
    [SerializeField] private GameObject _finishGamePoint;

    private float _gameProgress;
    private Vector3 _startPoint;
    private Vector3 _endPoint;

    public float GameProgress{ get { return _gameProgress; } }

    [Inject] private GameManager _gameManager;

    private void Start()
    {
        _startPoint = transform.position;
        _endPoint = _finishGamePoint.transform.position;
    }

    private void FixedUpdate()
    {
        if (_gameManager.IsGame())
        {
            float distanceToFinish = Vector3.Distance(transform.position, _endPoint);
            float totalDistance = Vector3.Distance(_startPoint, _endPoint);

            _gameProgress = 1f - Mathf.Clamp01(distanceToFinish / totalDistance);
        }
    }
}
