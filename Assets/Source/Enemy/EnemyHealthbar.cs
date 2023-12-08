using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    [SerializeField] private float _healthbarActiveTime = 0.4f;
    [SerializeField] private GameObject _enemyHealthbar;
    [SerializeField] private Slider _healthbarSlider;

    private float _procentOfHealth;
    private EnemyHealth _enemyHealth;
    private Camera _�amera;

    private void OnEnable()
    {
        _�amera = FindObjectOfType<Camera>();
        _enemyHealth = GetComponent<EnemyHealth>();
        if (_enemyHealth != null)
        {
            _enemyHealth.EnemyTakeDamage += ActivateHealthBar;
        }
    }

    private void Awake()
    {
        _healthbarSlider.value = 1.0f;
    }

    private void ActivateHealthBar()
    {
        ChangeHeathbarValue();
        _enemyHealthbar.transform.LookAt(_�amera.transform);
        _enemyHealthbar.gameObject.SetActive(true);
        StartCoroutine(DeactivateHealthBar(_healthbarActiveTime));
    }

    private void ChangeHeathbarValue()
    {
        _procentOfHealth = 1 / (float)_enemyHealth.MaxHealth;
        _healthbarSlider.value = _procentOfHealth * (float)_enemyHealth.CurrentHealth;
    }

    private IEnumerator DeactivateHealthBar(float healthbarActiveTime)
    {
        yield return new WaitForSeconds(healthbarActiveTime);
        _enemyHealthbar.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _enemyHealth.EnemyTakeDamage -= ActivateHealthBar;
    }
}
