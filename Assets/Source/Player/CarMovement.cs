using UnityEngine;
using Zenject;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private float _carSpeed = 5.0f;

    private bool IsStop;

    [Inject] private GameManager _gameManager;

    private void OnEnable()
    {
        CarHealth.CarDie += Stop;
    }

    private void Update()
    {
        if (_gameManager.IsGame())
        {
            Move();
        }
    }

    private void Move()
    {
        if (!IsStop)
        {
            transform.Translate(Vector3.forward * _carSpeed * Time.deltaTime);
        }
    }

    private void Stop()
    {
        IsStop = true;
    }
}
