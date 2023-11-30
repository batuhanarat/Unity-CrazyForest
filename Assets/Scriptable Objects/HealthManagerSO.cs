using System;
using UnityEngine;
using UnityEngine.Events;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName="HealthManagerScriptableObject",menuName="ScriptableObjects/HealthManager'")]
    public class HealthManagerSo : ScriptableObject
    {
        public int health = 100;
        [SerializeField] private int maxHealth = 100;
        [System.NonSerialized] public UnityEvent<int> HealthChangeEvent;

        private void OnEnable()
        {
            health = maxHealth;
            if (HealthChangeEvent == null)
            {
                HealthChangeEvent = new UnityEvent<int>();

            }
        }

        public void DecreaseHealth(int amount)
        {
            health -= amount;
            HealthChangeEvent.Invoke(health);
        }
        

  
    }
}
