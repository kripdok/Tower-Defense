using TMPro;
using UnityEngine;

public class PointCounterUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void DisplayVolumeOnScreen(int value)
    {
        _text.text = value.ToString();
    }
}
