using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CarDriveProgress : MonoBehaviour
{
    public GameObject finishGamePoint;
    public Slider progressSlider;

    private Vector3 _startPoint;
    private Vector3 _endPoint;

    [Inject] private GameManager _gameManager;

    private void Start()
    {
        _startPoint = transform.position;
        _endPoint = finishGamePoint.transform.position;
    }

    private void FixedUpdate()
    {
        if (_gameManager.IsGame())
        {
            float distanceToFinish = Vector3.Distance(transform.position, _endPoint);
            float totalDistance = Vector3.Distance(_startPoint, _endPoint);

            float progress = 1f - Mathf.Clamp01(distanceToFinish / totalDistance);

            if (progressSlider != null)
            {
                progressSlider.value = progress;
            }
        }
    }
}
