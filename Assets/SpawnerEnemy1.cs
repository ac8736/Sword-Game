using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerEnemy1 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<Transform> spawnAreas = new List<Transform>();

    private int spawnCount = 1;
    public float spawnDelay = 5;

    private bool currentlySpawning = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // exit code, remove later
        {
            StopAllCoroutines();
        }
        if (!currentlySpawning)
        {
            currentlySpawning = true;
            StartCoroutine(SpawnEnemies());
            StartCoroutine(DecreaseSpawnDelay());
        }
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            for (int i = 0; i < spawnCount; i++) 
            {    
                int randomIndex = Random.Range(0, spawnAreas.Count);
                Debug.Log(randomIndex);
                Instantiate(enemyPrefab, spawnAreas[randomIndex].position, spawnAreas[randomIndex].rotation);
            }
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    IEnumerator DecreaseSpawnDelay()
    {
        while (true)
        {
            if (spawnDelay > 1)
                spawnDelay -= 0.50f;
            if (GlobalVars.missileSpeed < 5.0f)
                GlobalVars.missileSpeed += 0.2f;
            if (spawnCount < 5)
                spawnCount += 1;
            yield return new WaitForSeconds(5);
        }
    }
}
