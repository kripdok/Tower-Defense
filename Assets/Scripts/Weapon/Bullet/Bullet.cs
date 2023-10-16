using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _spead;
    [SerializeField] private int _damage;

    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<HealthSystem>(out HealthSystem health))
        {
            health.CauseDamage(_damage);
        }

        EventBus.Instance.ReleasedBullet?.Invoke(this);
    }

    public void Init(Transform target, Transform firing)
    {
        transform.position = firing.position;
        Vector3 direction = (target.position - firing.position).normalized;
        _rigidBody.velocity = direction * _spead;
    }
}
