using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<TowerVaultIcon> _icons;
    [SerializeField] private PointCounter _counter;
    [SerializeField] private Builder _builder;

    private TowerVaultIcon _selectedIcon;

    private void Start()
    {
        ChangeButtonInteraction();
    }

    private void OnEnable()
    {
        _counter.PointsHasChanged += ChangeButtonInteraction;
        _builder.TowerVaultIsBuilt += SellTower;
    }

    private void OnDisable()
    {
        _counter.PointsHasChanged -= ChangeButtonInteraction;
        _builder.TowerVaultIsBuilt -= SellTower;
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

    public void PassTower(TowerVaultIcon icon)
    {
        _selectedIcon = icon;
        _builder.SetTower(icon.VaultTower);
    }

    private void SellTower()
    {
        EventBus.Instance.RemovePoint?.Invoke(_selectedIcon.Price);
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