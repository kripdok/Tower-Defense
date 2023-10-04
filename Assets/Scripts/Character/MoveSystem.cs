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
            _transform.LookAt(target.position);
            _rigidbody.velocity = direction * _speed;
            Rotation(target);

            if (Vector3.Distance(target.position, _transform.position) < 0.1)
            {
                _rigidbody.velocity = Vector3.zero;
                target = null;
                IsReachedTarget = true;
            }
        }
    }

    private void Rotation(Transform target)
    {
        Vector3 direction = target.position - _transform.position;
        Vector3 directionXY = new Vector3(direction.x, 0, direction.z);
        float angle = Vector3.SignedAngle(Vector3.forward, directionXY, Vector3.up);

        if (angle < 0)
        {
            angle += 360;
        }

        _transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}