using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Mover _mover;
    [SerializeField] private AnimationOperator _animationOperator;

    private void FixedUpdate()
    {
        if (_inputReader.RotateDirection != 0)
            _mover.Rotate(_inputReader.RotateDirection);

        if (_inputReader.MoveDirection != 0)
            _mover.Move(_inputReader.MoveDirection);

        _animationOperator.ToggleMode(_inputReader.IsMovingForward, _inputReader.IsMovingBack);
        _animationOperator.ToggleMoveAnimation(_inputReader.IsMovingForward, _inputReader.IsMovingBack);
    }
}
