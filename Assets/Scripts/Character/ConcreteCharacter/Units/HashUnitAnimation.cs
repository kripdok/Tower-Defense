using UnityEngine;

public class HashUnitAnimation : MonoBehaviour
{
    private int _TriggerAttackHash;
    private int _isMovingHash;

    public int IsMovingHash => _isMovingHash;
    public int TriggerAttackHash => _TriggerAttackHash;

    private void Awake()
    {
        _TriggerAttackHash = Animator.StringToHash("TriggerAttack");
        _isMovingHash = Animator.StringToHash("IsMoving");
    }
}
