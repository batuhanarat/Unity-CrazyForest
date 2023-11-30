using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class VectorEvent : UnityEvent<Vector3>
{

}

    public class Vector3EventListener: MonoBehaviour
    {
        [SerializeField] private Vector3EventChannelSO _channel = default;

        public VectorEvent OnEventRaised;

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

        private void Respond(Vector3 value)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value);
        }
    }
