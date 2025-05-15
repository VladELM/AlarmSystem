using UnityEngine;

[RequireComponent(typeof(Animator))]

public class AnimationOperator : MonoBehaviour
{
    [SerializeField] private string _moveBoolParameter;
    [SerializeField] private string _moveBlendParameter;
    [SerializeField] private float _backMoveBlendValue = 1;
    [SerializeField] private float _runBlendValue = 2;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void ToggleMode(bool isMovingForward, bool isMovingBack)
    {
        if (isMovingForward || isMovingBack)
            _animator.SetBool(_moveBoolParameter, true);
        else if (isMovingForward == false && isMovingBack == false)
            _animator.SetBool(_moveBoolParameter, false);
    }

    public void ToggleMoveAnimation(bool isMovingForward, bool isMovingBack)
    {
        if (isMovingForward)
            _animator.SetFloat(_moveBlendParameter, _runBlendValue);
        else if (isMovingBack)
            _animator.SetFloat(_moveBlendParameter, _backMoveBlendValue);
    }
}
