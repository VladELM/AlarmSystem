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
    private bool _isPlaying;
    private bool _isStopping;

    private void Awake()
    {
        _alarmZone = GetComponent<AlarmSystemZone>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _alarmZone.Entered += PlaySound;
        _alarmZone.Exited += StopSound;
    }

    private void Start()
    {
        _audioSource.volume = _minVlolumeValue;
        _isPlaying = false;
        _isStopping = false;
    }

    private void OnDisable()
    {
        _alarmZone.Entered -= PlaySound;
        _alarmZone.Exited -= StopSound;
    }

    private void PlaySound()
    {
        if (_isStopping)
        {
            StopCoroutine(Stopping());
            _isStopping = false;
        }

        StartCoroutine(Playing());
    }

    private void StopSound()
    {
        if (_isPlaying)
        {
            StopCoroutine(Playing());
            _isPlaying = false;
        }

        StartCoroutine(Stopping());
    }

    private IEnumerator Playing()
    {
        _audioSource.Play();
        _isPlaying = true;

        while (_isPlaying)
        {
            yield return null;

            float currentVolume = Mathf.MoveTowards(_audioSource.volume, _maxVlolumeValue, _delta * Time.deltaTime);
            _audioSource.volume = currentVolume;

            if (_audioSource.volume == _maxVlolumeValue)
                _isPlaying = false;
        }
    }

    private IEnumerator Stopping()
    {
        _isStopping  = true;

        while (_isStopping)
        {
            yield return null;

            float currentVolume = Mathf.MoveTowards(_audioSource.volume, _minVlolumeValue, _delta * Time.deltaTime);
            _audioSource.volume = currentVolume;

            if (_audioSource.volume == _minVlolumeValue)
                _isStopping = false;
        }

        _audioSource?.Stop();
    }
}
