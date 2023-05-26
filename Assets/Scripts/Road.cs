using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject roadPrefab;
    public float spawnDistance = 48.0f;
    public int initialRoadsCount = 5;
    bool gameover =false;

    private List<GameObject> spawnedRoads = new List<GameObject>();
    private Vector3 nextSpawnPosition = Vector3.zero;

    private void Start()
    {
        // Spawn initial roads
        for (int i = 0; i < initialRoadsCount; i++)
        {
            SpawnRoad();
        }
    }

    private void Update()
    {
        // Check if we need to spawn a new road
        if (Vector3.Distance(transform.position, nextSpawnPosition) <= spawnDistance)
        {
            SpawnRoad();
        }
    }

    public void SpawnRoad()
    {
        // Instantiate the road prefab
        GameObject road = Instantiate(roadPrefab, nextSpawnPosition, Quaternion.identity);
        spawnedRoads.Add(road);

        // Set the next spawn position to the end of the road
        nextSpawnPosition = road.transform.Find("EndPosition").position;
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the player enters the trigger, remove the first spawned road and update the next spawn position
        if (other.CompareTag("Player"))
        {
            Destroy(spawnedRoads[0]);
            spawnedRoads.RemoveAt(0);
            nextSpawnPosition = spawnedRoads[0].transform.Find("EndPosition").position;
        }
    }

   
}
