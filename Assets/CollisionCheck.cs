using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{

    // Start is called before the first frame update
    private Dictionary<GameObject, bool> triggeredPlatforms = new Dictionary<GameObject, bool>();
    [SerializeField]
    private IntEventChannelSO scoreEvent;
    [SerializeField] private ScoreStats Stats;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject collidedObject = other.gameObject;
        if (collidedObject.CompareTag("Hero"))
        {

            // Check if the platform has already been triggered before
            if (!triggeredPlatforms.ContainsKey(gameObject))
            {
                // Do whatever you want the trigger to do here for this specific platform
                Stats.Score.value += 10;
                scoreEvent.OnEventRaised( Stats.Score.value);
                // Add the platform to the dictionary with a value of true (triggered)
                triggeredPlatforms.Add(gameObject, true);
            }
            
        }

    }
}
