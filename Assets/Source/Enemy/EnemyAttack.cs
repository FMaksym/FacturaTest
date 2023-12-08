using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public bool IsPlayerInRange;
    public bool IsAttack;

    [SerializeField] private int _enemyDamage;
    [SerializeField] private float _findPlayerRadius;
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Animator _animator;

    private bool _IsCarDie;
    private CarHealth _player;

    private void OnEnable()
    {
        CarHealth.CarDie += CarDie;
        _player = FindObjectOfType<CarHealth>();
    }

    private void Start()
    {
        IdleAnimation();
    }

    private void Update()
    {
        if (!_IsCarDie)
        {
            FindPlayer();

            if (IsPlayerInRange && !_IsCarDie)
            {
                RunToPlayer();
                CheckForAttack();
            }else{
                IdleAnimation();
            }

            if (IsAttack && !_IsCarDie)
            {
                AttackAnimation();
            }
        }
        else
        {
            IdleAnimation();
        }
    }

    private void FindPlayer()
    {
        IsPlayerInRange = false;
        Collider[] colliders = Physics.OverlapSphere(transform.position, _findPlayerRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.GetComponent<CarHealth>() && !_IsCarDie)
            {
                IsPlayerInRange = true;
            }
        }
    }

    private void CheckForAttack()
    {
        IsAttack = false;
        Collider[] colliders = Physics.OverlapSphere(transform.position, _attackRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.GetComponent<CarHealth>() && !_IsCarDie)
            {
                IsAttack = true;
            }
        }
    }

    private void RunToPlayer()
    {
        if (!_IsCarDie)
        {
            RunAnimation();

            Vector3 direction = (_player.transform.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

            transform.Translate(direction * _movementSpeed * Time.deltaTime, Space.World);
        }
    }

    public int GiveDamage() => _enemyDamage;


    private void IdleAnimation()
    {
        _animator.SetBool("Idle", true);
        _animator.SetBool("Run", false);
        _animator.SetBool("Attack", false);
    }

    private void RunAnimation()
    {
        _animator.SetBool("Idle", false);
        _animator.SetBool("Run", true);
        _animator.SetBool("Attack", false);
    }

    private void AttackAnimation()
    {
        _animator.SetBool("Idle", false);
        _animator.SetBool("Run", false);
        _animator.SetBool("Attack", true);
    }

    private void CarDie() 
    {
        _IsCarDie = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _findPlayerRadius);
        Gizmos.DrawWireSphere(transform.position, _attackRadius);
    }

    private void OnDisable()
    {
        CarHealth.CarDie += CarDie;
    }
}
