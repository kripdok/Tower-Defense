using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TowerMenu : MonoBehaviour
{
    [SerializeField] private Button _upgrade;
    [SerializeField] private TMP_Text _upgradeText;
    [SerializeField] private Button _sell;
    [SerializeField] private TMP_Text _sellText;

    [SerializeField] private PointCounter _point;
    [SerializeField] private int _sellPriñe;
    [SerializeField] private Vector3 _positionOffset;

    private Tower _tower;

    private void Awake()
    {
        CloseMenu();
        _upgrade.interactable = false;
        _sellText.text = $"Sell ${_sellPriñe}";
    }

    private void OnEnable()
    {
        _upgrade.onClick.AddListener(Upgrade);
        _sell.onClick.AddListener(Sell);
    }

    private void OnDisable()
    {
        _upgrade.onClick.RemoveListener(Upgrade);
        _sell.onClick.RemoveListener(Sell);
    }

    public void SetTower(Tower tower)
    {
        _tower = tower;
        ActivateMenu(tower);
        _upgradeText.text = $"Upgrade ${tower.UpgradePrice}";
        tower.Died += CloseMenu;

        if(tower.IsUpgraded || _point.CorrectPoint < tower.UpgradePrice)
        {
            _upgrade.interactable = false;
        }
        else
        {
            _upgrade.interactable = true;
        }
    }

    public void CloseMenu()
    {
        gameObject.SetActive(false);

        if(_tower != null)
        {
            _tower.Died -= CloseMenu;
        }
    }

    private void ActivateMenu(Tower tower)
    {
        transform.position = tower.transform.position + _positionOffset;
        gameObject.SetActive(true);
    }

    private void Upgrade()
    {
        EventBus.Instance.RemovePoint.Invoke(_tower.UpgradePrice);
        _upgrade.interactable = false;
        _tower.Upgrade();
    }

    private void Sell()
    {
        EventBus.Instance.AddPoint.Invoke(_sellPriñe);
        _tower.TryGetComponent<HealthSystem>(out HealthSystem healthSystem);
        healthSystem.CauseDamage(1000);
        _tower = null;
        _upgrade.interactable = false;
    }
}
