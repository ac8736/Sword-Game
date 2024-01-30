using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject floorPrefab;
    public GameObject player;

    private bool spawning = false;

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
            int random = 0;// Random.Range(left, right);
            if (random == 0)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(player.transform.position.x - 8, player.transform.position.x + 8), Random.Range(player.transform.position.y - 10, player.transform.position.y - 30), player.transform.position.z);
                Instantiate(floorPrefab, spawnPosition, Quaternion.identity);
            }

            yield return new WaitForSeconds(0.2f);
        }
    }
}
