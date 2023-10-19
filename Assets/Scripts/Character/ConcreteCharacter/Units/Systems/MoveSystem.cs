using UnityEngine;

public class MoveSystem
{
    private Transform _transform;
    private float _speed;
    private Rigidbody _rigidbody;
    private RotateSystem _rotateSystem;

    public bool IsReachedTarget { get; private set;}

    public MoveSystem(Transform transform, float speed, Rigidbody rigidBody, RotateSystem rotateSystem)
    {
        _rotateSystem = rotateSystem;
        _transform = transform;
        _speed = speed;
        _rigidbody = rigidBody;
        IsReachedTarget = false;
    }

    public void Move(Transform target)
    {
        if (target != null)
        {
            _rotateSystem.Rotation(target);
            IsReachedTarget = false;
            Vector3 direction = (target.position - _transform.position).normalized;
            _rigidbody.velocity = direction * _speed;
            TryToStap(target);
        }
    }

    private void TryToStap(Transform target)
    {
        if (Vector3.Distance(target.position, _transform.position) < 0.1)
        {
            Stop();
            IsReachedTarget = true;
        }
    }

    public void Stop()
    {
        _rigidbody.velocity = Vector3.zero;
    }
}