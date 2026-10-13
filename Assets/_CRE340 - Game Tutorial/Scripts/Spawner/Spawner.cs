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


}
