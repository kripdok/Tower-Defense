using UnityEngine;

public class AttackState : State
{
    private Transform _target;

    public AttackState(int maxPriority = 3)
    {
        MaxPriority = maxPriority;
        ConcretePriority = 0;
    }

    public override void Enter()
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

    public override void LogicUpdate()
    {
        if (_target != null)
        {
            Debug.Log("Я атакую " + _target);
        }
        else
        {
            ConcretePriority = 0;
        }
            
    }

    public void StartAttack(Transform target)
    {
        _target = target;
        ConcretePriority = MaxPriority;
    }
}
