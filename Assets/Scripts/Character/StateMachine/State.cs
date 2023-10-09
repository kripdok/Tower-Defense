using Unity.VisualScripting;
using UnityEngine.Events;

public abstract class State
{
    protected int MaxPriority;
    protected StateMachine StateMachine;
    public int ConcretePriority { get; protected set; }

    public State(int maxPriority, StateMachine stateMachine)
    {
        MaxPriority = maxPriority;
        StateMachine = stateMachine;
        ConcretePriority = 0;
    }

    public abstract void LogicUpdate();

    public abstract void PhysicsUpdate();

    public abstract void Enter();

    public abstract void Exit();

}