using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{

    [Header("Fish Assignments - Put All Fish to Spawn Here")]
    public GameObject[] FishIShouldSpawn;

    [Header("Spawner Properties")]
    public float TimeBetweenSpawns = 0.5f;

    private float currentTime = 0;

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > TimeBetweenSpawns)
        {
            currentTime = 0;

            float offsetX = Random.Range(-5f, 5f);
            float offsetY = Random.Range(-5f, 5f);
            float offsetZ = 0;
            Vector3 spawnPosition = transform.position + new Vector3(offsetX, offsetY, offsetZ);

            int randomIndex = Random.Range(0, FishIShouldSpawn.Length);
            GameObject fishSpawned = Instantiate(FishIShouldSpawn[randomIndex]);
            fishSpawned.transform.position = spawnPosition;
        }
    }
}