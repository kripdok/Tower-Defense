using UnityEngine;

public class MoveSystem
{
    private Transform _transform;
    private float _speed;
    private Rigidbody _rigidbody;

    public bool IsReachedTarget { get; private set;}

    public MoveSystem(Transform transform, float speed, Rigidbody rigidbody)
    {
        _transform = transform;
        _speed = speed;
        _rigidbody = rigidbody;
        IsReachedTarget = false;
    }

    public void Move(Transform target)
    {
        if (target != null)
        {
            IsReachedTarget = false;
            Vector3 direction = (target.position - _transform.position).normalized;
            _rigidbody.velocity = direction * _speed;
            TryToStap(target);
        }
    }

    public void Stop()
    {
        _rigidbody.velocity = Vector3.zero;
    }

    private void TryToStap(Transform target)
    {
        if (Vector3.Distance(target.position, _transform.position) < 0.1)
        {
            Stop();
            IsReachedTarget = true;
        }
    }
}