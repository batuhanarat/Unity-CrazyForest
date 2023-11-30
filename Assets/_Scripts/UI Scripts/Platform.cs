using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts;
using _Scripts.Pool;
using DefaultNamespace;
using DefaultNamespace.InputHandler;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class Platform : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    private Transform _rigidbody2D;
    [SerializeField] private ScoreStats Stats;

    private void Start()
    {
        _rigidbody2D = gameObject.GetComponent<Transform>();
        Stats.Score.value = 0;
    }

    private void Update()
    {
        if (transform.position.y + 40 < Camera.main.transform.position.y ) // example condition: platform is too far below the camera
        {
            ObjectPooler.Instance.ReturnToPool(gameObject.tag, gameObject);
        }
    }
    
    private void OnDisable()
    {
        if (ObjectPooler.Instance.IsInitialized)
        {
            ObjectPooler.Instance.ReturnToPool(gameObject.tag, gameObject);
        }
    }
}