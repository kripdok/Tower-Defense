using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State CorrectState { get; protected set; }

    public void ChangeState(State nextState)
    {
        CorrectState.Exit();
        SetCorrectState(nextState);
    }

    protected void Initialize(State startState)
    {
        SetCorrectState(startState);
    }

    private void SetCorrectState(State state)
    {
        CorrectState = state;
        CorrectState.Enter();
    }
}