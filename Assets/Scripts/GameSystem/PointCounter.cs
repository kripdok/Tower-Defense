using UnityEngine;
using UnityEngine.Events;

public class PointCounter : MonoBehaviour
{
    [SerializeField] private PointCounterUI _pointCounterUI;

    private int _correctPoint;

    public int CorrectPoint => _correctPoint;

    public event UnityAction PointsHasChanged;

    public void Awake()
    {
        _correctPoint = 1200;
        _pointCounterUI.DisplayVolumeOnScreen(_correctPoint);
    }

    private void OnEnable()
    {
        EventBus.Instance.AddPoint += AddPoints;
        EventBus.Instance.RemovePoint += RemovePoints;
    }

    private void OnDisable()
    {
        EventBus.Instance.AddPoint -= AddPoints;
        EventBus.Instance.RemovePoint -= RemovePoints;
    }

    private void RemovePoints(int points)
    {
        _correctPoint -= points;
        TransmitChangeData();
    }

    private void AddPoints(int points)
    {
        _correctPoint += points;
        TransmitChangeData();
    }

    private void TransmitChangeData()
    {
        _pointCounterUI.DisplayVolumeOnScreen(_correctPoint);
        PointsHasChanged?.Invoke();
    }
}