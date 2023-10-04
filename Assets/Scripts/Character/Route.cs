using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    [SerializeField] private MoveState _moveState;
    [SerializeField] private List<Transform> _targets;

    private void Start()
    {
        _moveState.GetTarget(_targets);
    }
}
