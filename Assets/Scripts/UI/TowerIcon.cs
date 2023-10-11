using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TowerIcon : MonoBehaviour
{
    [SerializeField] private Tower _tower;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Shop _shop;

    public int Price => _tower.Price;
    public Tower Tower => _tower;

    public Button Button { get; private set; }

    private void Awake()
    {
        Button = GetComponent<Button>();
        Button.image.sprite = _tower.Icon;
        _name.text = _tower.Name;
        _price.text = "$"+_tower.Price.ToString();
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