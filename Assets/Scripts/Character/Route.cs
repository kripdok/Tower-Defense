using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    [SerializeField] private UnitStateMachine _unitStateMachine;
    [SerializeField] private List<Transform> _targets;

    private void Start()
    {
        _unitStateMachine._move.Enter(_targets);
    }
}
