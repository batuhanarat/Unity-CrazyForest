using System;
using UnityEngine;

namespace _Scripts.Enemy
{
    public class Movement : MonoBehaviour
    {

        public Rigidbody2D rb;
        public float speed = -50;
        public float raycastDistance = 30.0f; // Adjust this value based on the size of your beetle

        public void MoveTowardsTarget(Vector2 targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition,
                speed * Time.deltaTime);
            
        }

        public void MoveBeetle()
        {
            // Cast a ray in the direction the beetle is moving
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * speed, raycastDistance);

            // If the ray hit an edge
            if (hit.collider != null && hit.collider.gameObject.CompareTag("MainCamera"))
            {
                FlipAndChangeDirection();
            }

            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        public void FlipAndChangeDirection()
        {
            // Flip the direction
            speed = -speed;

            // If speed is positive, it's moving right, else left
            bool faceLeft = speed < 0;
            FlipCharacter(faceLeft);
        }

        public void FlipCharacter(bool faceLeft)
        {
            // Set the facing direction based on the input
            if (faceLeft)
                transform.rotation = Quaternion.Euler(0, 180, 0); // Flip left (rotate by 180 degrees on Y-axis)
            else
                transform.rotation = Quaternion.identity; // Flip right (reset rotation)
        }
      

    }
}