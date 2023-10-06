using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Platform : MonoBehaviour
{
    [SerializeField] private ObjectPool<Tower> _pool;
    [SerializeField] private Color _hoverColor;
    [SerializeField] private Vector3 _positionOffset;

    private Tower _tower;
    private Renderer _renderer;
    private Color _defoltColor;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _defoltColor = _renderer.material.color;
    }

    private void OnDisable()
    {
        if(_tower != null)
        {
            _tower.Died -= DeleteTower;
        }
    }

    private void OnMouseEnter()
    {
        _renderer.material.color = _hoverColor;
    }

    private void OnMouseDown()
    {
        if(_tower == null)
        {
            _tower = _pool.GetPrefab();
            _tower.transform.position = transform.position + _positionOffset;
            _tower.Died += DeleteTower;
        }
    }

    private void OnMouseExit() 
    {
        _renderer.material.color = _defoltColor;
    }


    private void DeleteTower()
    {
        _tower.Died -= DeleteTower;
        _pool.Release(_tower);
        _tower = null;
    }
}