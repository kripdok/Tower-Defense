public abstract class State
{
    protected int MaxPriority;

    public int ConcretePriority { get; protected set; }

    public abstract void Enter();

    public abstract void LogicUpdate();

    public abstract void Exit();
}