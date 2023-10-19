using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TowerVaultIcon : MonoBehaviour
{
    [SerializeField] private TowerVault _vaultTower;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Shop _shop;

    public int Price => _vaultTower.Price;
    public TowerVault VaultTower => _vaultTower;

    public Button Button { get; private set; }

    private void Awake()
    {
        Button = GetComponent<Button>();
        Button.image.sprite = _vaultTower.Icon;
        _name.text = _vaultTower.Name;
        _price.text = "$"+ _vaultTower.Price.ToString();
    }

    private void OnEnable()
    {
        Button.onClick.AddListener(RespondToPresses);
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(RespondToPresses);
    }

    private void RespondToPresses()
    {
        _shop.PassTower(this);
    }
}