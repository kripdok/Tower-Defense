using System.Collections.Generic;
using UnityEngine;

public class Route 
{
    private UnitStateMachine _unitStateMachine;
    private List<Transform> _targets;

    public Route(UnitStateMachine stateMachine)
    {
        _unitStateMachine = stateMachine;
    }

    public void Init(List<Transform> route)
    {
        _targets = route;
        _unitStateMachine.MoveState.SetRoute(_targets);
    }
}