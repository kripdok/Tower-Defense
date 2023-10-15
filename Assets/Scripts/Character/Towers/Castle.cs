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
        _health.HealthEnded += BecomingInactive;
    }

    private void OnDisable()
    {
        _health.HealthEnded -= BecomingInactive;
    }

    private void BecomingInactive()
    {
        gameObject.SetActive(false);
    }
}