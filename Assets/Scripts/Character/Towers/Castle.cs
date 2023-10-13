using UnityEngine;

[RequireComponent(typeof(HealthSystem))]
public class Castle : MonoBehaviour
{
    private HealthSystem _health;

    private void Awake()
    {
        _health = GetComponent<HealthSystem>();
    }

    private void OnEnable()
    {
        _health.Died += Die;
    }

    private void OnDisable()
    {
        _health.Died -= Die;
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}