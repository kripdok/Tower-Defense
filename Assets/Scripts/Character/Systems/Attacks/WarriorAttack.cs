using System.Collections;
using UnityEngine;

public class WarriorAttack : AttackSystem
{
    protected override IEnumerator Attack(Transform target)
    {
        while (target != null)
        {
            Debug.Log("� ��� �����");
            yield return target;
        }
    }
}