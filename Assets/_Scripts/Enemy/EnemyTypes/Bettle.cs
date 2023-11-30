// Bettle.cs
using System.Collections;
using System.Collections.Generic;
using _Scripts.Enemy;
using _Scripts.Pool;
using UnityEngine;

public class Bettle : MonoBehaviour, IPooledObject
{
    private EnemyThinker thinker;
    private LevelGenerator levelGenerator;

    void Start()
    {
        thinker = GetComponent<EnemyThinker>();
        levelGenerator = FindObjectOfType<LevelGenerator>();
    }

    private void Update()
    {
        if (transform.position.y + 100 < Camera.main.transform.position.y)
        {
            ReturnToPool();
        }
    }

    private void ReturnToPool()
    {
        if (gameObject.activeInHierarchy && ObjectPooler.Instance.IsInitialized)  // prevent double return due to multiple calls and ensure the pooler is initialized
        {
            ObjectPooler.Instance.ReturnToPool(gameObject.tag, gameObject);
            if (levelGenerator != null)
            {
                levelGenerator.beetleSpawned = false;  // Reset the flag
            }
        }
    }

    public void onObjectSpawn()
    {
    }
}