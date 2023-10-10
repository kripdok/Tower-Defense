using System.Collections;

public class TowerAttackSystem : AttackSystem
{
    protected override IEnumerator Attack(HealthSystem targetHealth)
    {
        while (targetHealth.CorrectHealth > 0)
        {
            targetHealth.CauseDamage(_damage);
            yield return _time;
        }
    }
}