using UnityEngine;

public class Sword : Weapon
{
    [SerializeField] private int _damage;

    public override void Attack(Transform target)
    {
        if(target.TryGetComponent<HealthSystem>(out HealthSystem health))
        {
            health.CauseDamage(_damage);
        }
    }
}
