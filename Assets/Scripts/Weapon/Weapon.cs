using UnityEngine;

public abstract class Weapon: MonoBehaviour
{
    [SerializeField] private float _delayBetweenAttack;

    public float DelayBetweenAttack => _delayBetweenAttack;

    public abstract void Attack(Transform target);
}
