using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.Events.EventListeners
{
    [System.Serializable]
    public class VoidEvent : UnityEvent
    {

    }

    public class VoidEventListener : MonoBehaviour
    {
        [SerializeField] private VoidEventChannelSO _channel = default;

        public VoidEvent OnEventRaised;
        public void OnEnable()
        {
            _channel.OnEventRaised += Response;
        }
        
        public void OnDisable()
        {
            _channel.OnEventRaised -= Response;
        }

        public void Response()
        {
            if(OnEventRaised != null)
                 OnEventRaised.Invoke();
        }
        

    }
}