using UnityEngine;
using UnityEngine.Events;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private UnitStateMachine _UnitStateMachine;
    [SerializeField] private float _radius;
    [Range(0, 360)]
    [SerializeField] private int _angleOfView;
    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private LayerMask _obstructionMask;

    private Transform _target;

    private void Update()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, _radius, _targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < _angleOfView / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (Physics.Raycast(transform.position, directionToTarget, distanceToTarget, _obstructionMask) == false)
                {
                    _target = target;
                    _UnitStateMachine._attack.StartAttack(_target);
                }
            }
            else
            {
                _target = null;
            }
        }
        else if (_target != null)
        {
            _target = null;
            _UnitStateMachine._attack.StartAttack(_target);
        }
    }
}
