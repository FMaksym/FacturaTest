public class EnemyHealth : Health
{
    public delegate void EnemyTakeDamageEventHandler();
    public delegate void EnemyDieFromBulletsEventHandler();
    public delegate void EnemyDieFromCollisionEventHandler();
    public event EnemyTakeDamageEventHandler EnemyTakeDamage;
    public event EnemyDieFromBulletsEventHandler EnemyDieFromBullets;
    public event EnemyDieFromCollisionEventHandler EnemyDieFromCollision;

    private void Awake()
    {
        Initialize();
    }

    protected override void Initialize()
    {
        MaxHealth = 10;
        base.Initialize();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (damage > 0)
        {
            EnemyTakeDamage?.Invoke();
        }
        DieFromBullet();
    }

    public void DieFromBullet()
    {
        if (CurrentHealth == 0)
        {
            base.Die();
            EnemyDieFromBullets?.Invoke();
        }
    }

    public void DieFromObstacle()
    {
        base.Die();
        EnemyDieFromCollision?.Invoke();
    }
}
