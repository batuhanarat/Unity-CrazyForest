using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

    [CreateAssetMenu(menuName = "Events/Vector3 Event Channel")]

    public class Vector3EventChannelSO: ScriptableObject
    {
        public UnityAction<Vector3> OnEventRaised;
        public void Raise(Vector3 value)
        {
            if (OnEventRaised != null)
            {
                OnEventRaised.Invoke(value);
            }
        }

    

    
}