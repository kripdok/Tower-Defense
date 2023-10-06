using UnityEngine.Events;

public abstract class State
{
    protected int MaxPriority;
    public int ConcretePriority { get; protected set; }

    public static event UnityAction OnPriorityChange;
    public State(int maxPriority)
    {
        MaxPriority = maxPriority;
        ConcretePriority = 0;
    }

    public abstract void LogicUpdate();

    public abstract void PhysicsUpdate();

    public abstract void Enter();

    public abstract void Exit();

    protected void Invoke()
    {
        OnPriorityChange?.Invoke();
    }
}