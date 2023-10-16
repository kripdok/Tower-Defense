using UnityEngine.Events;

public class EventBus 
{
    private static EventBus _instance;

    private EventBus() { }

    public static EventBus Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new EventBus();
            }

            return _instance;
        }
    }

    public UnityAction<int> AddPoint;
    public UnityAction<int> RemovePoint;

    public UnityAction UnitDied;

    public UnityAction<Unit> ReleasedUnit;
    public UnityAction<Tower> ReleasedTower;
    public UnityAction<Bullet> ReleasedBullet;

}
