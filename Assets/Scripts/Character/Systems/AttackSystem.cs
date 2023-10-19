using System.Collections;
using UnityEngine;

public abstract class AttackSystem : MonoBehaviour
{
    private Coroutine _coroutine;

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