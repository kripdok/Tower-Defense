using UnityEngine;
using UnityEngine.Events;

public class PointCounter : MonoBehaviour
{
    [SerializeField] private PointCounterUI _pointCounterUI;
    [SerializeField] private Shop _shop;

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
        Unit.PassPoints += AddPoints;
    }

    private void OnDisable()
    {
        Unit.PassPoints -= AddPoints;
    }

    public void ReducePoints(int points)
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