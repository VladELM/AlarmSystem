using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private float _minVlolumeValue = 0;
    [SerializeField] private float _maxVlolumeValue = 1;
    [SerializeField] private float _delta = 0.01f;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _audioSource.volume = _minVlolumeValue;
    }

    public void ManageAlarming(bool isAlarming)
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
