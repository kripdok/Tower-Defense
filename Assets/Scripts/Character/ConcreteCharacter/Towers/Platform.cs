using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Platform : MonoBehaviour
{
    [SerializeField] private Color _hoverColor;
    [SerializeField] private Vector3 _positionOffset;

    private TowerVault _vaultTowers;
    private Renderer _renderer;
    private Color _defoltColor;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _defoltColor = _renderer.material.color;
    }

    private void OnDisable()
    {
        if(_vaultTowers != null)
        {
            _vaultTowers.Died -= DeleteTowerVault;
        }
    }

    private void OnMouseEnter()
    {
        _renderer.material.color = _hoverColor;
    }

    private void OnMouseExit() 
    {
        _renderer.material.color = _defoltColor;
    }

    public void SetTower(TowerVault towerVault)
    {
        _vaultTowers = towerVault;
        _vaultTowers.transform.position = transform.position + _positionOffset;
        _vaultTowers.BuildFirstTower();
        _vaultTowers.Died += DeleteTowerVault;
    }

    private void DeleteTowerVault()
    {
        _vaultTowers.Died -= DeleteTowerVault;
        _vaultTowers = null;
    }
}