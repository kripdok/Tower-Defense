using System.Collections.Generic;
using UnityEngine;

public class SystemCreateUnit : MonoBehaviour
{
    [SerializeField] private UnitButton Warrior;
    [SerializeField] private UnitButton Archer;
    [SerializeField] private List<FactoryButton> _factoryBattons;

    private Unit _concreteUnit;

    private void OnEnable()
    {
        Warrior.PressedTheButton += SetTheWarriorToCreate;
        Archer.PressedTheButton += SetTheWarriorToCreate;
    }

    private void OnDisable()
    {
        Warrior.PressedTheButton -= SetTheWarriorToCreate;
        Archer.PressedTheButton -= SetTheWarriorToCreate;
    }

    private void SetTheWarriorToCreate(Unit unit)
    {
        _concreteUnit = unit;
        TransmitTheUnitsToFactorys();
    }

    private void TransmitTheUnitsToFactorys()
    {
        foreach(var factory in _factoryBattons)
        {
            factory.InitUnit(_concreteUnit);
        }
    }
}