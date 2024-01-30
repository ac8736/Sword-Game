using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject floorPrefab;
    public GameObject player;

    private int left = 0;
    private int right = 1;
    private bool spawning = false;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawning)
        {
            StartCoroutine(Spawn());
            spawning = true; 
        }
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            int random = Random.Range(left, right);
            if (random == 0)
            {
                Vector3 spawnPosition = new Vector3(player.transform.position.x, Random.Range(player.transform.position.y - 10, player.transform.position.y - 30), player.transform.position.z);
                Instantiate(floorPrefab, spawnPosition, Quaternion.identity);
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}
