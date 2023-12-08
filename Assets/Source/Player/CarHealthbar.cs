using UnityEngine;
using UnityEngine.UI;

public class CarHealthbar : MonoBehaviour
{
    [SerializeField] private Slider _carHealthbar;
    [SerializeField] private CarHealth _carHealth;

    private float _procentOfHealth;

    private void OnEnable()
    {
        CarHealth.CarTakeDamage += ChangeHeathbarValue;
    }

    private void Awake()
    {
        _carHealthbar.value = 1.0f;
    }

    private void ChangeHeathbarValue()
    {

        _procentOfHealth = 1 / (float)_carHealth.MaxHealth;
        _carHealthbar.value = _procentOfHealth * (float)_carHealth.CurrentHealth;
    }

    private void OnDisable()
    {
        CarHealth.CarTakeDamage -= ChangeHeathbarValue;
    }
}
