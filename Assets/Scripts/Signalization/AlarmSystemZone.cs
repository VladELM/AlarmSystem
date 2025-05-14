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
        if (other.TryGetComponent(out AlarmListener alarmListener))
            _alarmSystem.RunAlarmSound();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out AlarmListener alarmListener))
            _alarmSystem.TurnOnMuteMode();
    }
}
