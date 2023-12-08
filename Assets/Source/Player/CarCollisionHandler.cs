using UnityEngine;

public class CarCollisionHandler : MonoBehaviour
{
    [SerializeField] private CarHealth _carHealth;

    private PlayerDamageTextActivate _playerDamageText;

    private void Awake()
    {
        _playerDamageText = FindObjectOfType<PlayerDamageTextActivate>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyHealth>())
        {
            other.gameObject.GetComponent<EnemyHealth>().DieFromObstacle();
            _carHealth.TakeDamage(other.gameObject.GetComponent<EnemyAttack>().GiveDamage());
            HitPlayer(other.gameObject.GetComponent<EnemyAttack>().GiveDamage());
        }
    }

    private void HitPlayer(int damage)
    {
        _playerDamageText.ActivateText(transform.position + new Vector3(0, 3.5f, 0), damage);
    }
}
