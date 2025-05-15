using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AlarmSystemZone))]
[RequireComponent(typeof(AudioSource))]

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private float _minVlolumeValue = 0;
    [SerializeField] private float _maxVlolumeValue = 1;
    [SerializeField] private float _delta = 0.01f;

    private AlarmSystemZone _alarmZone;
    private AudioSource _audioSource;

    private void Awake()
    {
        _alarmZone = GetComponent<AlarmSystemZone>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _alarmZone.Collided += ManageAlarming;
    }

    private void Start()
    {
        _audioSource.volume = _minVlolumeValue;
    }

    private void OnDisable()
    {
        _alarmZone.Collided -= ManageAlarming;
    }

    private void ManageAlarming(bool isAlarming)
    {
        float targetVolumeValue = 0;

        if (isAlarming)
        {
            targetVolumeValue = _maxVlolumeValue;
            _audioSource.Play();
        }
        else
        {
            targetVolumeValue = _minVlolumeValue;
        }

        StartCoroutine(SoundManaging(targetVolumeValue));

        if (isAlarming == false && _audioSource.volume == _minVlolumeValue)
            _audioSource?.Stop();
    }

    private IEnumerator SoundManaging(float targetVolumeValue)
    {
        while (enabled)
        {
            yield return null;

            float currentVolume = Mathf.MoveTowards(_audioSource.volume, targetVolumeValue, _delta * Time.deltaTime);
            _audioSource.volume = currentVolume;

            if (_audioSource.volume == targetVolumeValue)
                break;
        }
    }
}
