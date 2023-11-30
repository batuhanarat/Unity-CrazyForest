using System;
using Scriptable_Objects;
using UnityEngine;

namespace Events
{
    public class HealthDecreaseEvent : MonoBehaviour
    {
        [SerializeField, Tooltip("How much should the player's health decrease by when entering this trigger.")]
        private int healthDecreaseAmount = 10;

        [SerializeField] private HealthManagerSo _healthManagerSo;

      

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Hero"))
            {
                _healthManagerSo.DecreaseHealth(healthDecreaseAmount);
            }
        }
    }
}