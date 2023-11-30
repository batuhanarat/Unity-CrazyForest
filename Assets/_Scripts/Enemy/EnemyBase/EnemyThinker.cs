using System;
using _Scripts.Enemy.Brains;
using UnityEngine;

namespace _Scripts.Enemy
{
    public class EnemyThinker: MonoBehaviour
    {
        public Brain brain;

        private void Update()
        {
            brain.Think(this);
        }
        
    }
}