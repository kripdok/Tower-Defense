using UnityEngine;

public class RotateSystem
{
    private Transform _transform;

    public RotateSystem(Transform transform)
    {
        _transform = transform;
    }

    public void Rotation(Transform target)
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