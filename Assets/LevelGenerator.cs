using System.Collections.Generic;
using _Scripts.Pool;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;
    public int numberOfPlatforms = 500;
    public int screenWidth = 18;
    public int minY = 5;
    public int maxY = 11;
    public float maxX;  // Added a new public variable
    [SerializeField]public ScoreStats score;
    public bool beetleSpawned = false;
    public bool vultureSpawned = false;

    private Vector3 lastSpawnPosition = Vector3.zero;
    private Queue<Vector3> positions = new Queue<Vector3>();
    private List<GameObject> platforms = new List<GameObject>();
    private GameObject hero;

    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");
        maxX = screenWidth / 2f;  // Compute maxX based on screenWidth

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            EnqueueNewPosition();
        }

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            SpawnPlatform();
        }
    }

    void FixedUpdate()
    {
        if (platforms.FindAll(p => !p.activeInHierarchy).Count >= numberOfPlatforms / 2)
        {
            for (int i = 0; i < numberOfPlatforms / 2; i++)
            {
                SpawnPlatform();
            }
        }

        if (score.Score.value % 90 == 0 && score.Score.value != 0 && !beetleSpawned)
        {
            SpawnBeetle();
            beetleSpawned = true;
        }

        if (score.Score.value % 200 == 0 && score.Score.value != 0 && !vultureSpawned)
        {
            SpawnVulture();
            vultureSpawned = true;
        }
    }

    private void SpawnPlatform()
    {
        if (positions.Count > 0 && ObjectPooler.Instance.PoolNotEmpty("Platform"))
        {
            Vector3 spawnPosition = positions.Dequeue();
            GameObject newPlatform = ObjectPooler.Instance.SpawnFromPool("Platform", spawnPosition, Quaternion.identity);
            platforms.Add(newPlatform);
            EnqueueNewPosition();
        }
    }

    private void SpawnBeetle()
    {
        Vector3 spawnPosition = hero.transform.position + new Vector3(-16, 10, 0);
        //spawnPosition.x = Random.Range(-maxX, maxX);
        ObjectPooler.Instance.SpawnFromPool("Bettle", spawnPosition, Quaternion.identity);
    }

    private void SpawnVulture()
    {
        Vector3 spawnPosition = hero.transform.position + new Vector3(-4, 24, 0);
        //spawnPosition.x = Random.Range(-maxX, maxX);
        ObjectPooler.Instance.SpawnFromPool("Vulture", spawnPosition, Quaternion.identity);
    }

    private void EnqueueNewPosition()
    {
        lastSpawnPosition.y += Random.Range(minY, maxY);
        lastSpawnPosition.x = Random.Range(-maxX, maxX);  // Use maxX here
        positions.Enqueue(lastSpawnPosition);
    }
}

