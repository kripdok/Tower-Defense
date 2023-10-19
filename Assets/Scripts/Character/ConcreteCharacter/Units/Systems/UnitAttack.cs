using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(HashUnitAnimation))]
public class UnitAttack : AttackSystem
{
    [SerializeField] private Weapon _weapon;

    private HashUnitAnimation _hashAnimation;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _hashAnimation = GetComponent<HashUnitAnimation>();
    }

    protected override IEnumerator Attack(Transform target)
    {
        while (target.gameObject.activeSelf)
        {
            _animator.SetTrigger(_hashAnimation.TriggerAttackHash);
            _weapon.Attack(target);
            yield return new WaitForSeconds(_weapon.DelayBetweenAttack);
        }
    }
}