using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Mover _mover;
    [SerializeField] private AnimationManager _animationManager;

    private void FixedUpdate()
    {
        if (_inputReader.RotateDirection != 0)
            _mover.Rotate(_inputReader.RotateDirection);

        if (_inputReader.MoveDirection != 0)
            _mover.Move(_inputReader.MoveDirection);

        _animationManager.ToggleMode(_inputReader.IsMovingForward, _inputReader.IsMovingBack);
        _animationManager.ToggleMoveAnimation(_inputReader.IsMovingForward, _inputReader.IsMovingBack);
    }
}
