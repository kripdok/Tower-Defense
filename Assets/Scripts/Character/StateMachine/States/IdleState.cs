using UnityEngine;

public class IdleState : State
{
    public IdleState(int maxPriority = 1) 
    {
        MaxPriority = maxPriority;
        ConcretePriority = maxPriority;
    }

    public override void Enter()
    {
        Debug.Log("� ����� ������");
    }
    public override void LogicUpdate()
    {
        Debug.Log("� ����");
    }

    public override void Exit()
    {
        
    }
}
