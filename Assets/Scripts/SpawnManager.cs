using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject [] penguinPrefabs;
    private float spawnRangeX = 12;
    private float spawnPosZ = 25;
    private float startDelay = 1f;
    private float spawnInterval = 1.7f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomPenguin", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomPenguin()
    {
        int penguinIndex = Random.Range(0, penguinPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(penguinPrefabs[penguinIndex], spawnPos, penguinPrefabs[penguinIndex].transform.rotation);
    }
}