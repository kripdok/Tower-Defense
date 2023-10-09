using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    protected List<State> States;

    public State CorrectState { get; protected set; }

    private void Update()
    {
        CorrectState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        CorrectState.PhysicsUpdate();
    }

    public void ExitAllStates()
    {
        foreach (var state in States)
        {
            state.Exit();
        }
    }

    public void SetStateWithTheMaxPriority()
    {
        State state = States.OrderByDescending(state => state.ConcretePriority).FirstOrDefault();

        if (CorrectState != null)
        {
            ChangeState(state);
        }
        else
        {
            Initialize(state);
        }
    }

    protected void ChangeState(State nextState)
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