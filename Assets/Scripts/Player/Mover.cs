using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 150;
    [SerializeField] private float _runSpeed = 2.5f;
    [SerializeField] private float _backRunSpeed = 1.5f;

    public void Rotate(float rotateDirection)
    {
        transform.Rotate(rotateDirection * _rotateSpeed * Time.deltaTime * Vector3.up);
    }

    public void Move(float moveDirection)
    {
        float distance = moveDirection * GetSpeed(moveDirection) * Time.deltaTime;
        transform.Translate(distance * Vector3.forward);
    }

    private float GetSpeed(float direction)
    {
        float speed = 0;

        if (direction > 0)
            speed = _runSpeed;
        else if (direction < 0)
            speed = _backRunSpeed;

        return speed;
    }
}
