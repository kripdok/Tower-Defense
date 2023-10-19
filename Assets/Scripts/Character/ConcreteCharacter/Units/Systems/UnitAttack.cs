using System.Collections;
using UnityEngine;

public class UnitAttack : AttackSystem
{
    [SerializeField] private HashUnitAnimation _animation;
    [SerializeField] private Weapon _weapon;

    protected override IEnumerator Attack(Transform target)
    {
        while (target.gameObject.activeSelf)
        {
            _weapon.Attack(target);
            yield return new WaitForSeconds(_weapon.DelayBetweenAttack);
        }
    }
}