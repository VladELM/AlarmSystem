using UnityEngine;

public class Movement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _rotateSpeed = 150;
    [SerializeField] private float _runSpeed = 2.5f;
    [SerializeField] private float _backRunSpeed = 1.5f;

    private void Update()
    {
        Rotate();
        Move();
    }
    private void Rotate()
    {
        float rotation = Input.GetAxis(Horizontal);
        transform.Rotate(rotation * _rotateSpeed * Time.deltaTime * Vector3.up);
    }

    private void Move()
    {
        float offset = Input.GetAxis(Vertical);
        float speed = 0;

        if (offset > 0)
            speed = _runSpeed;
        else if (offset < 0)
            speed = _backRunSpeed;

        float distance = offset * speed * Time.deltaTime;
        transform.Translate(distance * Vector3.forward);
    }

}
