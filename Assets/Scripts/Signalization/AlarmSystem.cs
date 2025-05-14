using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private float _minVlolumeValue = 0;
    [SerializeField] private float _maxVlolumeValue = 1;
    [SerializeField] private float _delta = 0.01f;

    private AudioSource _audioSource;
    private bool _isIncreasing;
    private bool _isRedicing;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _audioSource.volume = _minVlolumeValue;
        _isIncreasing = false;
        _isRedicing = true;
    }

    private void Update()
    {
        if (_isIncreasing)
            IncreaseVolume();

        if (_isRedicing)
            ReduceVolume();
    }

    public void RunAlarmSound()
    {
        _audioSource.Play();
        _isIncreasing = true;
    }

    public void TurnOnMuteMode()
    {
        _isRedicing = true;
        _isIncreasing = false;
    }

    private void IncreaseVolume()
    {
        float currentVolume = Mathf.MoveTowards(_audioSource.volume, _maxVlolumeValue, _delta * Time.deltaTime);
        _audioSource.volume = currentVolume;

        if (currentVolume == _maxVlolumeValue)
            _isIncreasing = false;
    }

    private void ReduceVolume()
    {
        float currentVolume = Mathf.MoveTowards(_audioSource.volume, _minVlolumeValue, _delta * Time.deltaTime);
        _audioSource.volume = currentVolume;

        if (currentVolume == _minVlolumeValue)
        {
            _isRedicing = false;
            _audioSource?.Stop();
        }
    }
}
