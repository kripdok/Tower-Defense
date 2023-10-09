using UnityEngine;
using UnityEngine.Events;

public class PointCounter : MonoBehaviour
{
    [SerializeField] private PointCounterUI _pointCounterUI;

    private int _correctPoint;

    public int CorrectPoint => _correctPoint;

    public event UnityAction MilestoneReached;

    public void Awake()
    {
        _correctPoint = 0;
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

    private void AddPoints(int points)
    {
        _correctPoint += points;
        _pointCounterUI.DisplayVolumeOnScreen(_correctPoint);
    }
}