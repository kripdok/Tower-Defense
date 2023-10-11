using UnityEngine;

public class MouseClickHandler : MonoBehaviour
{
    [SerializeField] private LayerMask clickLayerMask;

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
        Debug.Log("Clicked on: " + clickedObject.name);
    }
}