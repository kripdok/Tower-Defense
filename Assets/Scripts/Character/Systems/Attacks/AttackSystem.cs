using System.Collections;
using UnityEngine;

public abstract class AttackSystem :MonoBehaviour
{
    [SerializeField] private HashUnitAnimation _animation;
    [SerializeField] private float _delayBetweenAttack;
    [SerializeField] protected int _damage;

    protected WaitForSeconds _time;
    private Coroutine _coroutine;

    private void Start()
    {
        _time = new WaitForSeconds(_delayBetweenAttack);
    }

    public void PrepareToStrike(HealthSystem targetHealth)
    {
        TryFinishAttack();
        _coroutine = StartCoroutine(Attack(targetHealth));
    }

    public void TryFinishAttack()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    protected abstract IEnumerator Attack(HealthSystem targetHealth);
}