using UnityEngine;

public class MouseClickHandler : MonoBehaviour
{
    [SerializeField] private LayerMask clickLayerMask;
    [SerializeField] private Builder _builder;
    [SerializeField] private TowerMenu _menu;

    private InputActionControls _input;

    private void Awake()
    {
        _input = new InputActionControls();
        _input.Enable();
    }

    private void OnEnable()
    {
        _input.Cursor.Pressing.performed += cnt => HandleMouseClick();
    }

    private void OnDisable()
    {
        _input.Cursor.Pressing.performed -= cnt => HandleMouseClick();
    }

    private void HandleMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, clickLayerMask))
        {
            GameObject clickedObject = hit.collider.gameObject;
            HandleClick(clickedObject);
        }
    }

    private void HandleClick(GameObject clickedObject)
    {
        if (clickedObject.TryGetComponent<Platform>(out Platform platform))
        {
            _builder.TryBuildTowerOnPlatform(platform);
            _menu.CloseMenu();
        }  
        else if(clickedObject.TryGetComponent<Tower>(out Tower tower))
        {
            _menu.SetTower(tower);
        }
        else
        {
            _menu.CloseMenu();
        }
    }
}