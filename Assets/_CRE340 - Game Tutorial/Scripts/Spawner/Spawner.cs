using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("What to Spawn")]
    public GameObject[] prefabsToSpawn;

    [Header("Where to Spawn")]
    public Vector3 spawnArea = new Vector3(20f, 0f, 20f);
    public float spawnHeight = 0.5f;

    [Header("Spawn at the Start")]
    public bool spawnOnStart = true;
    public int startingAmount = 5;

    [Header("Keep spawning")]
    public bool spawningContinuously = false;
    public float minSpawnInterval = 2f;
    public float maxSpawnInterval = 5f;
    public int maxAlive = 20;


    [SerializeField]
    private List<GameObject> spawnedObjects = new List<GameObject>();

    void Start()
    {
        if (spawnOnStart)
        {
            for (int i = 0; i < startingAmount; i++)
            {
                SpawnOne();
            }
        }

        if (spawningContinuously)
        {
            StartCoroutine(SpawnLoop());
        }
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(waitTime);

            if (GameManagerWeek5.Instance.IsGameOver)
            {
                yield break;
            }


            CleanUpList();

            if (spawnedObjects.Count < maxAlive)
            {
                SpawnOne();
            }
        }    
    }
    
    private void SpawnOne()
    {
        if (prefabsToSpawn.Length == 0)
        {
            Debug.LogWarning("Spawner on " + gameObject.name + " has no prefabs assigned!");
            return;
        }

        int randomIndex = Random.Range(0, prefabsToSpawn.Length);
        GameObject prefabToSpawn = prefabsToSpawn[randomIndex];

        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
            spawnHeight,
            Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

        randomPosition = randomPosition + transform.position;

        GameObject newObject = Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);
        spawnedObjects.Add(newObject);
    }

    private void CleanUpList()
    {
        for (int i = spawnedObjects.Count - 1; i >= 0; i--)
        {
            if (spawnedObjects[i] == null)
            {
                spawnedObjects.RemoveAt(i);
            }
        }
    }

    public int GetAliveCount()
    {
        CleanUpList();
        return spawnedObjects.Count;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.lightGreen;
        Gizmos.DrawWireCube(transform.position, spawnArea);
    }
}
