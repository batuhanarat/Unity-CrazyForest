using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroColliderScript : MonoBehaviour
{
    // Start is called before the first frame update

    private bool heroInsideBlock = false;

    private void Update()
    {
        // Check for jumping or moving up.
        bool isJumping = Input.GetKeyDown(KeyCode.Space) || GetComponent<Rigidbody2D>().velocity.y > 0;
        if (heroInsideBlock && !isJumping)
        {
            // If the hero is inside the block and not jumping, disable collisions with the block.
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("HeroLayer"), LayerMask.NameToLayer("Default"), true);
        }
        else
        {
            // Otherwise, enable collisions with the block.
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("HeroLayer"), LayerMask.NameToLayer("Default"), false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Block"))
        {
            heroInsideBlock = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Block"))
        {
            heroInsideBlock = false;
        }
    }
}


