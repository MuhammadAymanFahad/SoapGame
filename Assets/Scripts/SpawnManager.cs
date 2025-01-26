using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefabToSpawn; 
    public float spawnInterval = 2f; 
    public Vector2 spawnAreaMin; 
    public Vector2 spawnAreaMax; 

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            SpawnPrefab();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnPrefab()
    {
        float randomX = Random.Range(-30, 30);
        float randomY = Random.Range(-12, 13);
        Vector2 spawnPosition = new Vector2(randomX, randomY);

        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}

