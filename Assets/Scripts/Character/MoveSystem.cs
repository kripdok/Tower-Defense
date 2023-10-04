using UnityEngine;
using UnityEngine.Events;

public class MoveSystem : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigidbody;

    public event UnityAction AchievedTarget;

    public void Move(Transform target)
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.LookAt(target.position);
            _rigidbody.velocity = direction * _speed;
            Rotation(target);

            if (Vector3.Distance(target.position, transform.position) < 0.1)
            {
                _rigidbody.velocity = Vector3.zero;
                target = null;
                AchievedTarget?.Invoke();
            }
        }
    }

    private void Rotation(Transform target)
    {
        Vector3 direction = target.position - transform.position;
        Vector3 directionXY = new Vector3(direction.x, 0, direction.z);
        float angle = Vector3.SignedAngle(Vector3.forward, directionXY, Vector3.up);

        if (angle < 0)
        {
            angle += 360;
        }

        transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}
