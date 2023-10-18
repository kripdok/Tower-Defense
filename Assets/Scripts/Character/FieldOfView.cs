using UnityEngine;

public abstract class FieldOfView : MonoBehaviour
{
    [SerializeField] private float _radius;
    [Range(0, 360)]
    [SerializeField] private int _angleOfView;
    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private LayerMask _obstructionMask;

    protected Transform _target;
    private readonly int NumberOfFieldOfViewBoundaries = 2;

    private void Update()
    {
        FindingTheTarget();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

    private void FindingTheTarget()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, _radius, _targetMask);

        if (_target == null)
        {
            
            if (rangeChecks.Length != 0)
            {
                Transform target = rangeChecks[0].transform;
                Vector3 directionToTarget = (target.position - transform.position).normalized;

                TryToSeeTargetFromAnAngleOfView(directionToTarget, target);
            }
        }
        else 
        {
            if (_target.gameObject.activeSelf == false || Vector3.Distance(_target.transform.position, transform.position) > _radius+1)
            {
                ClearTarget();
            }
        }
    }

    private void TryToSeeTargetFromAnAngleOfView(Vector3 directionToTarget, Transform target)
    {
        if (Vector3.Angle(transform.forward, directionToTarget) < _angleOfView / NumberOfFieldOfViewBoundaries)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if (TargetIsBehindTheBarrier(directionToTarget, distanceToTarget) == false)
            {
                SeeTheTarget(target);
            }
        }
        
    }

    private bool TargetIsBehindTheBarrier(Vector3 directionce, float distance)
    {
        return Physics.Raycast(transform.position, directionce, distance, _obstructionMask);
    }

    protected abstract void ClearTarget();

    protected abstract void SeeTheTarget(Transform target);
}