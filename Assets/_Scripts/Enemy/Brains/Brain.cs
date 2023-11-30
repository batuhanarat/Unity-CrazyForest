using UnityEngine;

namespace _Scripts.Enemy.Brains
{
    public abstract class Brain: ScriptableObject
    {
        public abstract void Think(EnemyThinker thinker);
    }
}