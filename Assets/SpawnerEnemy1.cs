using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy1 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<Transform> spawnAreas = new List<Transform>();
    public int spawnDelay = 5;

    private bool currentlySpawning = false;
    private Coroutine coroutine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // exit code, remove later
        {
            StopCoroutine(coroutine);
        }
        if (!currentlySpawning)
        {
            currentlySpawning = true;
            coroutine = StartCoroutine(SpawnEnemies());
        }
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            int randomIndex = new System.Random().Next(0, spawnAreas.Count);
            Instantiate(enemyPrefab, spawnAreas[randomIndex].position, spawnAreas[randomIndex].rotation);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
