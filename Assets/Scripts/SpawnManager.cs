using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomAnimmalFromSide", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        GameObject animalPrefab = animalPrefabs[animalIndex];
        Instantiate(animalPrefab, spawnPos, animalPrefab.transform.rotation);
    }

    void SpawnRandomAnimmalFromSide()
    {
        // Side random switch from left, right at random
        int[] side = { -1, 1 };
        int sideRandom = side[Random.Range(0, 2)];
        Vector3 spawnPos = new Vector3(-30 * sideRandom, 0, Random.Range(-spawnRangeX, spawnRangeX));
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        GameObject animalPrefab = animalPrefabs[animalIndex];
        Instantiate(animalPrefab, spawnPos, Quaternion.Euler(new Vector3(0, 90 * sideRandom, 0)));
    }
}
