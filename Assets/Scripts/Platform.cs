using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Renderer))]
public class Platform : MonoBehaviour
{
    [SerializeField] private Color _hoverColor;
    [SerializeField] private Vector3 _positionOffset;

    private Tower _tower;
    private Renderer _renderer;
    private Color _defoltColor;

    public static event UnityAction<Platform> OnPlatformReady;
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
        if (_tower == null)
        {
            OnPlatformReady?.Invoke(this);
        }
    }

    private void OnMouseExit() 
    {
        _renderer.material.color = _defoltColor;
    }

    public void SetTower(Tower Tower)
    {
        _tower = Tower;
        _tower.transform.position = transform.position + _positionOffset;
        _tower.Died += DeleteTower;
    }


    private void DeleteTower()
    {
        _tower.Died -= DeleteTower;
        _tower = null;
    }
}