using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<TowerIcon> _icons;
    [SerializeField] private PointCounter _counter;
    [SerializeField] private Builder _builder;

    private TowerIcon _selectedIcon;

    private void Start()
    {
        ChangeButtonInteraction();
    }

    private void OnEnable()
    {
        _counter.PointsHasChanged += ChangeButtonInteraction;
        _builder.TowerIsBuilt += SellTower;
    }

    private void OnDisable()
    {
        _counter.PointsHasChanged -= ChangeButtonInteraction;
    }

    private void ChangeButtonInteraction()
    {
        foreach (var icon in _icons)
        {
            if (icon.Price > _counter.CorrectPoint)
            {
                icon.Button.interactable = false;
            }
            else
            {
                icon.Button.interactable = true;
            }
        }
    }

    public void PassTower(TowerIcon icon)
    {
        _selectedIcon = icon;
        _builder.SetTower(icon.Tower);
    }

    private void SellTower()
    {
        _counter.ReducePoints(_selectedIcon.Price);
        CheckSelectIconForSaleability();
    }

    private void CheckSelectIconForSaleability()
    {
        if(_selectedIcon.Button.interactable == false)
        {
            _selectedIcon = null;
            _builder.SetTower(null);
        }
    }
}