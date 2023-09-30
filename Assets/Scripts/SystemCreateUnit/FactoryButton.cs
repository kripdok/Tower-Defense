using UnityEngine;
using UnityEngine.UI;

public class FactoryButton : MonoBehaviour
{
    [SerializeField] private AbstractFactory _factory;
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
        switch (_unit)
        {
            case Warrior:
                _factory.CreateWarrior();
                break;
            case Archer:
                _factory.CreateArcher();
                break;

        }
    }
}