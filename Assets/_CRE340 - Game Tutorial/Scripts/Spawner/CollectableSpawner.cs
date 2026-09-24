using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{

    public GameObject collectablePrefab;

    public int numberOfCollectables = 10;
    public Vector3 spawnArea; // set xyz coordinates in inspector.
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        SpawnCollectables();
    }

    // Update is called once per frame
    void SpawnCollectables()
    {
        for (int i = 0; i < numberOfCollectables; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                Random.Range(0, spawnArea.y),
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

            Instantiate(collectablePrefab, randomPosition, Quaternion.identity);
        }
    }

    void OnDrawGizmoSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, spawnArea);
    }
}
