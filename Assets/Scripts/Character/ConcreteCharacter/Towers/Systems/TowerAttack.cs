using System.Collections;
using UnityEngine;

public class TowerAttack : AttackSystem
{
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private Transform _muzzle;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _delayBetweenAttack;

    protected override IEnumerator Attack(Transform target)
    {
        while (target.gameObject.activeSelf)
        {
            yield return new WaitForSeconds(_delayBetweenAttack);
            InitializeBullet(target);
        }
    }

    private void InitializeBullet(Transform target)
    {
        var bullet = _bulletPool.GetPrefab(_bullet);
        bullet.Init(target, _muzzle);
    }
}