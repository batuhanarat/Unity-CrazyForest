using UnityEngine;

namespace DefaultNamespace
{
    public abstract class Movement : ScriptableObject
    {

        public abstract void MoveTowards(Vector2 destination);
        public abstract float MovementSpeed { get; }
        public abstract void StopMovement();
        public abstract void FlipDirection();
    }
}