using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private int _bulletDamage;
    [SerializeField] private int _addCoinValue;

    private EnemyDamageTextActivate _enemyDamageText;
    private CoinTextActivate _coinText;
    private EnemyHealth enemyHealth;

    private void OnEnable()
    {
        _enemyDamageText = FindObjectOfType<EnemyDamageTextActivate>();
        _coinText = FindObjectOfType<CoinTextActivate>();
    }

    private void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            transform.Translate(Vector3.forward * _bulletSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyHealth>())
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(_bulletDamage);
            HitEnemy(other);
            gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }

    private void HitEnemy(Collider other)
    {
        _enemyDamageText.ActivateText(transform.position + new Vector3(0, 2, 0), _bulletDamage);

        enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.EnemyDieFromBullets += KillEnemy;
        }
    }

    private void KillEnemy()
    {
        _coinText.ActivateText(enemyHealth.transform, _addCoinValue);
    }
}
