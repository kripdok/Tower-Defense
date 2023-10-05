using System.Collections;
using UnityEngine;

public abstract class AttackSystem :MonoBehaviour
{
    [SerializeField] private HashUnitAnimation _animation;
    [SerializeField] private float _delayBetweenAttack;

    protected WaitForSeconds _time;
    private Coroutine _coroutine;

    private void Start()
    {
        _time = new WaitForSeconds(_delayBetweenAttack);
    }

    public void PrepareToStrike(Transform target)
    {
        TryFinishAttack();
        _coroutine = StartCoroutine(Attack(target));
    }

    public void TryFinishAttack()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    protected abstract IEnumerator Attack(Transform target);
}
