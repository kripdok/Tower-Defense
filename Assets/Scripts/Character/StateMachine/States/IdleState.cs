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
        Debug.Log("Я начал стаять");
    }
    public override void LogicUpdate()
    {
        Debug.Log("Я стою");
    }

    public override void Exit()
    {
        
    }
}
