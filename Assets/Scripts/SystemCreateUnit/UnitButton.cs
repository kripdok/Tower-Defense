using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UnitButton : MonoBehaviour
{
    [SerializeField] private Unit _unit;
    [SerializeField] private Button _button;

    public event UnityAction<Unit> PressedTheButton;

    private void OnEnable()
    {
        _button.onClick.AddListener(TransmitUnit);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(TransmitUnit);
    }

    private void TransmitUnit()
    {
        PressedTheButton?.Invoke(_unit);
    }
}