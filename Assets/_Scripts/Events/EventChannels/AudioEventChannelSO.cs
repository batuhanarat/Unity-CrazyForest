using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.Events.EventChannels
{
    [CreateAssetMenu(menuName = "Events/Audio Event Channel")]

    public class AudioEventChannelSO: ScriptableObject
    {
        public UnityAction<AudioClip> OnEventRaised;

        public void Raise(AudioClip value)
        {
            if (OnEventRaised != null)
            {
                OnEventRaised.Invoke(value);
            }
        }
    }
}