using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private UnitStateMachine _UnitStateMachine;
    [SerializeField] private float _radius;
    [Range(0, 360)]
    [SerializeField] private int _angleOfView;
    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private LayerMask _obstructionMask;

    private readonly int NumberOfFieldOfViewBoundaries = 2;
    private Transform _target;

    private void Update()
    {
        FindingTheTarget();
    }

    private void FindingTheTarget()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, _radius, _targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            TryToSeeTargetFromAnAngleOfView(directionToTarget, target);
        }
        else if (_target != null)
        {
            _target = null;
            _UnitStateMachine.AttackState.SetTarget(_target);
        }
    }

    private void TryToSeeTargetFromAnAngleOfView(Vector3 directionToTarget, Transform target )
    {
        if (Vector3.Angle(transform.forward, directionToTarget) < _angleOfView / NumberOfFieldOfViewBoundaries)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            TryToSeeTheTarget(directionToTarget, distanceToTarget, target);
        }
    }

    private void TryToSeeTheTarget(Vector3 directionce, float distance, Transform target)
    {
        if (Physics.Raycast(transform.position, directionce, distance, _obstructionMask) == false)
        {
            _target = target;
            _UnitStateMachine.AttackState.SetTarget(_target);
        }
    }
}