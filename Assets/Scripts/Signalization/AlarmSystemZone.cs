using UnityEngine;

[RequireComponent(typeof(AlarmSystem))]

public class AlarmSystemZone : MonoBehaviour
{
    private AlarmSystem _alarmSystem;

    private void Awake()
    {
        _alarmSystem = GetComponent<AlarmSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Thief thief))
            _alarmSystem.ManageAlarming(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Thief thief))
            _alarmSystem.ManageAlarming(false);
    }
}
