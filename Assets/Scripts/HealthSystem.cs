using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int _health;
    protected int _correctHealth;

    public event UnityAction Died;

    public int CorrectHealth => _correctHealth;

    private void Awake()
    {
        AddMaxHealth();
    }

    public virtual void CauseDamage(int damage)
    {
        _correctHealth -= damage;

        if (_correctHealth <= 0)
        {
            _correctHealth = 0;
            Died?.Invoke();
        }
    }

    public void AddMaxHealth()
    {
        _correctHealth = _health;
    }
}
