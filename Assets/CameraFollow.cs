using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    [SerializeField] private Vector3EventChannelSO cameraEvent;
  

    
    // Update is called once per frame
    void LateUpdate()
    {
        if (target.position.y > transform.position.y)
        {
            //lerp ile yaparsan daha pürüzsüz olur
            //smooth camera follow video
            Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = newPos;
            cameraEvent.OnEventRaised(this.transform.position);
        }
    }

}
