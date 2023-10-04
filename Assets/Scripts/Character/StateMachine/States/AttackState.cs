using UnityEngine;

public class AttackState : State
{
    private Transform _target;

    public AttackState(int maxPriority = 3) : base(maxPriority)
    {
    }

    public void Enter(Transform target)
    {
        _target = target;
        Enter();
    }

    public override void Enter()
    {
        ConcretePriority = MaxPriority;
    }

    public override void LogicUpdate()
    {
        if (_target != null)
        {
            Debug.Log("� ������ " + _target);
        }
        else
        {
            ConcretePriority = 0;
        }
    }

    public override void PhysicsUpdate()
    {
        
    }
}
