using UnityEngine;

namespace DefaultNamespace
{
    public class HeroMovement : Movement
    {
        public override void MoveTowards(Vector2 destination)
        {
            throw new System.NotImplementedException();
        }

        public override float MovementSpeed { get; }
        public override void StopMovement()
        {
            throw new System.NotImplementedException();
        }

        public override void FlipDirection()
        {
            throw new System.NotImplementedException();
        }
    }
}