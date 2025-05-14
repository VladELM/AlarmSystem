using UnityEngine;

[RequireComponent(typeof(Animator))]

public class AnimationManager : MonoBehaviour
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

    private void Update()
    {
        ToggleMoveMode();
        ToggleMoveAnimation();
    }

    private void ToggleMoveMode()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            _animator.SetBool(_moveBoolParameter, true);
        else if (Input.GetKey(KeyCode.W) == false && Input.GetKey(KeyCode.S) == false)
            _animator.SetBool(_moveBoolParameter, false);
    }

    private void ToggleMoveAnimation()
    {
        if (Input.GetKey(KeyCode.W))
            _animator.SetFloat(_moveBlendParameter, _runBlendValue);
        else if (Input.GetKey(KeyCode.S))
            _animator.SetFloat(_moveBlendParameter, _backMoveBlendValue);
    }
}
