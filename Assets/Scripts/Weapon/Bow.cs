using UnityEngine;

public class Bow :Weapon
{
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private Transform _muzzle;
    [SerializeField] private Bullet _bullet;

    public override void Attack(Transform target)
    {
        var bullet = _bulletPool.GetPrefab(_bullet);
        bullet.Init(target, _muzzle);
    }
}
