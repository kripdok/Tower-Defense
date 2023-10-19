public class BulletPool : ObjectPool<Bullet>
{
    private void OnEnable()
    {
        EventBus.Instance.ReleasedBullet += Release;
    }

    private void OnDisable()
    {
        EventBus.Instance.ReleasedBullet -= Release;
    }
}
