using TMPro;
using UnityEngine;
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

    private TowerVault _towerVault;

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

    public void SetTower(TowerVault towerVault)
    {
        _towerVault = towerVault;
        ActivateMenu(towerVault);
        _upgradeText.text = $"Upgrade ${towerVault.UpgradePrice}";
        towerVault.Died += CloseMenu;

        if (towerVault.IsUpgradeLimitReached || _point.CorrectPoint < towerVault.UpgradePrice)
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

        if(_towerVault != null)
        {
            _towerVault.Died -= CloseMenu;
        }
    }

    private void ActivateMenu(TowerVault towerVault)
    {
        transform.position = towerVault.transform.position + _positionOffset;
        gameObject.SetActive(true);
    }

    private void Upgrade()
    {
        EventBus.Instance.RemovePoint.Invoke(_towerVault.UpgradePrice);
        _upgrade.interactable = false;
        _towerVault.Upgrade();
    }

    private void Sell()
    {
        EventBus.Instance.AddPoint.Invoke(_sellPriñe);
        _towerVault.Sell();
        _towerVault = null;
        _upgrade.interactable = false;
        gameObject.SetActive(false);
    }
}
