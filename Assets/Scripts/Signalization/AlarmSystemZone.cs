using System;
using UnityEngine;

public class AlarmSystemZone : MonoBehaviour
{
    public event Action Entered;
    public event Action Exited;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Thief thief))
            Entered?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Thief thief))
            Exited?.Invoke();
    }
}
