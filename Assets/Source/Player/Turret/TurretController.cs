using UnityEngine;
using Zenject;

public class TurretController : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 5.0f;
    [SerializeField] private float _rotationAngle = 45.0f;

    private bool IsRotating = false;
    private Vector2 _startTouchPosition;

    [Inject] private GameManager _gameManager;

    private void FixedUpdate()
    {
        if (_gameManager.IsGame())
        {
            HandleInput();
        }
    }

    private void HandleInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    StartRotation(touch.position);
                    break;

                case TouchPhase.Moved:
                    ContinueRotation(touch.position);
                    break;

                case TouchPhase.Ended:
                    StopRotation();
                    break;
            }
        }
    }

    private void StartRotation(Vector2 touchPosition)
    {
        IsRotating = true;
        _startTouchPosition = touchPosition;
    }

    private void ContinueRotation(Vector2 touchPosition)
    {
        if (IsRotating)
        {
            float rotationAmount = (touchPosition.x - _startTouchPosition.x) * _rotationSpeed * Time.deltaTime;
            RotateTurret(rotationAmount);
            _startTouchPosition = touchPosition;
        }
    }

    private void StopRotation()
    {
        IsRotating = false;
    }

    private void RotateTurret(float amount)
    {
        float currentRotation = transform.rotation.eulerAngles.y;
        float newRotation = currentRotation + amount;

        newRotation = (newRotation > 180.0f) ? newRotation - 360.0f : newRotation;
        newRotation = Mathf.Clamp(newRotation, -_rotationAngle, _rotationAngle);

        transform.rotation = Quaternion.Euler(-90.0f, newRotation, 0.0f);
    }
}
