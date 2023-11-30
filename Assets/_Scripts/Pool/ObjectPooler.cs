using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Pool
{
    public class ObjectPooler : MonoBehaviour
    {
        [System.Serializable]
        public class Pool
        {
            public string tag;
            public GameObject prefab;
            public int size;
        }

        #region Singleton

        public static ObjectPooler Instance;

        private void Awake()
        {
            Instance = this;
        }

        #endregion

        public List<Pool> pools;
        public Dictionary<string, Queue<GameObject>> poolDictionary;

        // New variable to check initialization status
        public bool IsInitialized { get; private set; } = false;

        void Start()
        {
            poolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach (Pool pool in pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                for (int i = 0; i < pool.size; i++)
                {
                    GameObject obj = Instantiate(pool.prefab);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }
                poolDictionary.Add(pool.tag,objectPool);
            }
            
            IsInitialized = true;  // Set initialization flag to true
            
            foreach (var key in poolDictionary.Keys)
            {
                Debug.Log("Pool Dictionary Key: " + key);
            }

        }

        public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
        {
            if (!poolDictionary.ContainsKey(tag))
            {
                Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
                return null;
            }

            if (poolDictionary[tag].Count == 0)
            {
                Debug.LogWarning("Pool with tag " + tag + " is empty.");
                return null;
            }

            GameObject objectToSpawn = poolDictionary[tag].Dequeue();

            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

            return objectToSpawn;
        }

        
        public bool PoolNotEmpty(string tag)
        {
            if (!poolDictionary.ContainsKey(tag))
            {
                Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
                return false;
            }

            return poolDictionary[tag].Count > 0;
        }


        public void ReturnToPool(string tag, GameObject objectToReturn)
        {
            Debug.Log("Returning to pool: " + tag);

            if (IsInitialized)
            {
                objectToReturn.SetActive(false);
                poolDictionary[tag].Enqueue(objectToReturn);
            }
        }

    }
}
