using UnityEngine;
using UnityEngine.UI;

public class FactoryButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    private Unit _unit;

    private void Awake()
    {
        _unit = null;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(CreateUnit);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(CreateUnit);
    }

    public void InitUnit(Unit unit)
    {
        _unit = unit;
    }

    private void CreateUnit()
    {
    }
}