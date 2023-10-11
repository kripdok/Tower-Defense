using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMoveSystem : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5.0f;
    [SerializeField] private float _xLimit;
    [SerializeField] private float _zLimit;

    [SerializeField] private float _zoomSpeed = 2.0f;
    [SerializeField] private float _minZoom;
    [SerializeField] private float _maxZoom;

    private InputActionControls _input;
    private Vector2 XBoundaries;
    private Vector2 ZBoundaries;

    private float _minZoomDistance;
    private float _maxZoomDistance;

    private float currentZoomDistance;

    private void Start()
    {
        _input = new InputActionControls();
        _input.Enable();

        XBoundaries = new Vector2(transform.position.x - _xLimit, transform.position.x + _xLimit);
        ZBoundaries = new Vector2(transform.position.z - _zLimit, transform.position.z + _zLimit);

        _minZoomDistance = transform.position.y - _minZoom;
        _maxZoomDistance = transform.position.y + _maxZoom;
        currentZoomDistance = transform.position.y;
    }

    private void Update()
    {
        Vector2 direction = _input.Camera.Move.ReadValue<Vector2>();
        float zoom = _input.Camera.Zoom.ReadValue<float>();
        Move(direction);
        Zoom(zoom);
    }

    private void Move(Vector2 direction)
    {
        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
        Vector3 newPosition = transform.position + moveDirection * _moveSpeed * Time.deltaTime;
        float clampedX = Mathf.Clamp(newPosition.x, XBoundaries.x, XBoundaries.y);
        float clampedZ = Mathf.Clamp(newPosition.z, ZBoundaries.x, ZBoundaries.y);
        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);
    }

    private void Zoom(float zoom)
    {
        currentZoomDistance = Mathf.Clamp(currentZoomDistance - zoom * _zoomSpeed * Time.deltaTime, _minZoomDistance, _maxZoomDistance);
        Vector3 zoomPosition = transform.position;
        zoomPosition.y = currentZoomDistance;
        transform.position = zoomPosition;
    }
}