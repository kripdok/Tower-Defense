using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int _health;
    protected int _correctHealth;

    public int CorrectHealth => _correctHealth;

    public UnityAction HealthEnded;

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
            HealthEnded?.Invoke();
        }
    }

    public void AddMaxHealth()
    {
        _correctHealth = _health;
    }
}