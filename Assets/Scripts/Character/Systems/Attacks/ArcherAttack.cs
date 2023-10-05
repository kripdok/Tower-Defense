using System.Collections;
using UnityEngine;

public class ArcherAttack : AttackSystem
{
    protected override IEnumerator Attack(Transform target)
    {
        while(target != null)
        {
            Debug.Log("я стрел€ю из лука");
            yield return target;
        }
    }
}
