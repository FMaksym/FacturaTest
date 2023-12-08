using UnityEngine;

public class CarDetailActive : MonoBehaviour
{
    [SerializeField] private GameObject _crosshair;
    [SerializeField] private GameObject _healthbar;
    [SerializeField] private GameObject[] _dirtParticle;

    private void OnEnable()
    {
        GameManager.StartGame += ActivateCarDetails;
        CarHealth.CarDie += DeactivateCarDetails;
        FinishGameControl.FinishGame += DeactivateCarDetails;
    }

    private void ActivateCarDetails()
    {
        _crosshair.gameObject.SetActive(true);
        _healthbar.gameObject.SetActive(true);
        foreach (var particle in _dirtParticle)
        {
            particle.gameObject.SetActive(true);
        }
    }

    private void DeactivateCarDetails()
    {
        _crosshair.gameObject.SetActive(false);
        _healthbar.gameObject.SetActive(false);
        foreach (var particle in _dirtParticle)
        {
            particle.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        GameManager.StartGame -= ActivateCarDetails;
        CarHealth.CarDie -= DeactivateCarDetails;
        FinishGameControl.FinishGame -= DeactivateCarDetails;
    }
}
