using DefaultNamespace;
using UnityEngine;

namespace _Scripts
{
    [CreateAssetMenu(menuName = "Movement/HorizontalMovement")]

    public class HorizontalMovement : Movement
    {

        private Rigidbody2D _rigidbody;
        private Vector2 _desiredDirection;
        
        [SerializeField]
        private float _movementSpeed = 5f;

        public override float MovementSpeed => _movementSpeed;
        
        private void Update()
        {
            _rigidbody.velocity = _desiredDirection * _movementSpeed;
        }
        
        public override void MoveTowards(Vector2 direction)
        {
            _desiredDirection = direction;
        }

        public override void StopMovement()
        {
            _desiredDirection = Vector2.zero;
        }

        public override void FlipDirection()
        {
            _desiredDirection = _desiredDirection * -1;
            
        }

        
    }
}