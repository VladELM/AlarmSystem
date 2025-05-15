using System;
using UnityEngine;

public class AlarmSystemZone : MonoBehaviour
{
    public event Action<bool> Collided;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Thief thief))
            Collided?.Invoke(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Thief thief))
            Collided?.Invoke(false);
    }
}
