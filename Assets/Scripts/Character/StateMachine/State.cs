using UnityEngine;

public abstract class State
{
    private StateMachine _stateMachine;

    public State(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public abstract void Enter();

    public abstract void Update();

    public abstract void Exit();

    private void ChangeState(State state)
    {
        _stateMachine.ChangeState(state);
    }
}