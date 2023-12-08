using UnityEngine;

public class Health : MonoBehaviour
{
    private int _currentHealth;

    public int MaxHealth { get;  set; }

    public int CurrentHealth
    {
        get => _currentHealth;
        set
        {
            _currentHealth = Mathf.Clamp(value, 0, MaxHealth);
        }
    }

    protected virtual void Initialize()
    {
        CurrentHealth = MaxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
    }
    
    public virtual void Die()
    {
        gameObject.SetActive(false);
    }
}
