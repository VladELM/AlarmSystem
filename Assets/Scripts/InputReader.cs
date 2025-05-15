using UnityEngine;

public class InputReader : MonoBehaviour
{
    private string Horizontal = nameof(Horizontal);
    private string Vertical = nameof(Vertical);

    public float MoveDirection { get; private set; }
    public float RotateDirection { get; private set; }
    public bool IsMovingForward { get; private set; }
    public bool IsMovingBack { get; private set; }

    private void Start()
    {
        IsMovingForward = false;
        IsMovingBack = false;
    }

    private void Update()
    {
        MoveDirection = Input.GetAxis(Vertical);
        RotateDirection = Input.GetAxis(Horizontal);

        IsMovingForward = Input.GetKey(KeyCode.W);
        IsMovingBack = Input.GetKey(KeyCode.S);
    }
}
