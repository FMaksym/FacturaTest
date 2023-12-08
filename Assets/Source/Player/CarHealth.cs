using System.Collections;
using UnityEngine;

public class CarHealth : Health
{
    [SerializeField] private int _carMaxHealth;

    public delegate void CarTakeDamageEventHandler();
    public delegate void CarHalfHealthEventHandler();
    public delegate void CarQuarterHealthEventHandler();
    public delegate void CarDieEventHandler();
    public static event CarTakeDamageEventHandler CarTakeDamage;
    public static event CarHalfHealthEventHandler CarHalfHealth;
    public static event CarQuarterHealthEventHandler CarQuarterHealth;
    public static event CarDieEventHandler CarDie;

    private void Awake()
    {
        Initialize();
    }

    protected override void Initialize()
    {
        MaxHealth = _carMaxHealth;
        base.Initialize();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        CarTakeDamage?.Invoke();
        HalfHealth();
        QuarterHealth();
        Die();
    }

    public void HalfHealth()
    {
        if (CurrentHealth == MaxHealth / 2)
        {
            CarHalfHealth?.Invoke();
        }
    }

    public void QuarterHealth()
    {
        if (CurrentHealth <= MaxHealth / 4)
        {
            CarQuarterHealth?.Invoke();
        }
    }

    public override void Die()
    {
        if (CurrentHealth == 0)
        {
            CarDie?.Invoke();
            StartCoroutine(WaitAndDie(4));
        }
    }

    private IEnumerator WaitAndDie(float time)
    {
        yield return new WaitForSeconds(time);
        base.Die();
    }
}
