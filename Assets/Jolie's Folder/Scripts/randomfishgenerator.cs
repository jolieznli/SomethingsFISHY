using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomfishgenerator : MonoBehaviour
{
    public GameObject endangeredfishPrefab;
    public GameObject endangeredfishBabyPrefab;
    public GameObject invasivefishPrefab;
    public GameObject invasivefishBabyPrefab;
    public GameObject normalfishPrefab;
    public GameObject normalfishBabyPrefab;

    float currentTime = 0;

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > 0.5f)
        {
            currentTime = 0;

            float offsetX = Random.Range(-0.02f, 0.02f);
            float offsetY = Random.Range(-0.02f, 0.02f);
            float offsetZ = 0;
            Vector3 spawnPosition = transform.position + new Vector3(offsetX, offsetY, offsetZ);

            GameObject[] fishPrefabs = new GameObject[]
            {
                endangeredfishPrefab,
                endangeredfishBabyPrefab,
                invasivefishPrefab,
                invasivefishBabyPrefab,
                normalfishPrefab,
                normalfishBabyPrefab
            };

            int randomIndex = Random.Range(0, fishPrefabs.Length);
            //Instantiate(fishPrefabs[randomIndex], spawnPosition, Quaternion.identity);
            GameObject fish = Instantiate(fishPrefabs[randomIndex], spawnPosition, Quaternion.identity);

            // Scale everything down to 30% of original size
            fish.transform.localScale *= 0.3f;
        }
    }
}
