public class StateMachine
{
    public State CorrectState;

    public void Initialize(State startState)
    {
        SetCorrectState(startState);
    }

    public void ChangeState(State nextState)
    {
        CorrectState.Enter();
        SetCorrectState(nextState);
    }

    private void SetCorrectState(State state)
    {
        CorrectState = state;
        CorrectState.Enter();
    }
}