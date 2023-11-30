using _Scripts.Events.EventChannels;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public partial class AudioEvent : UnityEvent<AudioClip> { }

public class AudioEventListener : MonoBehaviour
{
    [SerializeField] private AudioEventChannelSO _channel = default;
    public AudioManager audioManager;
    
    private void OnEnable()
    {
        if (_channel != null)
            _channel.OnEventRaised += Respond;
    }

    private void OnDisable()
    {
        if (_channel != null)
            _channel.OnEventRaised -= Respond;
    }

    private void Respond(AudioClip value)
    {
        audioManager.PlayClip(value);
    }
}